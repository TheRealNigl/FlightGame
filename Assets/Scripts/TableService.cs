using System.Collections.Generic;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class TableService : MonoBehaviour
{
    private static Table scoreTable;

    public Button listTableButton;
    public Button updateTableButton;
    public Button proceedTableButton;
    public Button describeTableButton;
    public Text resultText;
    public InputField Username;


    private string IdentityPoolId = "us-east-1:8711af53-3285-4755-b7d7-4f07f53de79b";
    private string CognitoPoolRegion = RegionEndpoint.USEast1.SystemName;
    private string DynamoRegion = RegionEndpoint.USEast1.SystemName;

    private IAmazonDynamoDB _client;

    private RegionEndpoint _CognitoPoolRegion {
        get { return RegionEndpoint.GetBySystemName(CognitoPoolRegion); }
    }

    private RegionEndpoint _DynamoRegion {
        get { return RegionEndpoint.GetBySystemName(DynamoRegion); }
    }

    private static IAmazonDynamoDB _ddbClient;

    private AWSCredentials _credentials;

    private AWSCredentials Credentials {
        get {
            if (_credentials == null)
                _credentials = new CognitoAWSCredentials(IdentityPoolId, _CognitoPoolRegion);
            return _credentials;
        }
    }

    protected IAmazonDynamoDB Client {
        get {
            if (_ddbClient == null) {
                _ddbClient = new AmazonDynamoDBClient(Credentials, _DynamoRegion);
            }

            return _ddbClient;
        }
    }

    private void Start() {

        UnityInitializer.AttachToGameObject(this.gameObject);
        proceedTableButton.onClick.AddListener(FindRepliesForAThreadSpecifyOptionsLimitListener);
        describeTableButton.onClick.AddListener(LoadTableListener);
        listTableButton.onClick.AddListener(ListTableListener);
        updateTableButton.onClick.AddListener(UpdateTableListener);

        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;

        _client = Client;
    }

    private void LoadTableListener() {

        Debug.Log("Leaderboard");
        resultText.text = "Leaderboards: ";
        Table.LoadTableAsync(_client, "Score", (loadTableResult) => {
            if (loadTableResult.Exception != null) {
                resultText.text += "\n failed to load score table";
            } else {
                scoreTable = loadTableResult.Result;
                SendTopScore();
            }
        });
    }

    public void SendTopScore(){

        var score = new Document();
        score["Name"] = Username.text;
        score["Score"] = GameController.Score;
        scoreTable.PutItemAsync(score, (r) => { });

        resultText.text = score.ToString();
    }


    void FindRepliesForAThreadSpecifyOptionsLimitListener()
    {
        FindRepliesForAThreadSpecifyOptionalLimitHelper(null);
    }

    private void FindRepliesForAThreadSpecifyOptionalLimitHelper(Dictionary<string, AttributeValue> lastKeyEvaluated)
    {
        Debug.Log("Find reply");
        string forumName = "Amazon DynamoDB";
        string threadSubject = "DynamoDB Thread 1";
        string replyId = forumName + "#" + threadSubject;

        resultText.text = ("Leaderboards: ");

        var request = new QueryRequest
        {
            TableName = "Score",
            ReturnConsumedCapacity = "TOTAL",
            KeyConditions = new Dictionary<string, Condition>()
                {
                    {
                        "Username",
                        new Condition
                        {
                            ComparisonOperator = "EQ",
                            AttributeValueList = new List<AttributeValue>()
                            {
                                new AttributeValue { S = replyId }
                            }
                        }
                    }
                },
            Limit = 8,
            ExclusiveStartKey = lastKeyEvaluated
        };

        _client.QueryAsync(request, (result) =>
        {
            resultText.text += "Listings: ";
            foreach (Dictionary<string, AttributeValue> item
                     in result.Response.Items)
            {
                PrintItem(item);
            }
            lastKeyEvaluated = result.Response.LastEvaluatedKey;
            if (lastKeyEvaluated != null && lastKeyEvaluated.Count != 0)
            {
                FindRepliesForAThreadSpecifyOptionalLimitHelper(lastKeyEvaluated);
            }
        });
    }

    private void PrintItem(Dictionary<string, AttributeValue> attributeList)
    {
        foreach (var kvp in attributeList)
        {
            string attributeName = kvp.Key;
            AttributeValue value = kvp.Value;

            resultText.text +=
            (
                  "\n User: " + attributeName + " " +
                  (value.S == null ? "" : "Scored: " + value.S + "]")
            );
        }
    }

    void ListTableListener()
    {
        resultText.text = "\n*** listing tables ***";
        string lastTableNameEvaluated = null;

        var request = new ListTablesRequest
        {
            Limit = 2,
            ExclusiveStartTableName = lastTableNameEvaluated
        };

        Client.ListTablesAsync(request, (result) =>
        {
            if (result.Exception != null)
            {
                resultText.text += result.Exception.Message;
                return;
            }

            resultText.text += "ListTable response : \n";
            var response = result.Response;
            foreach (string name in response.TableNames)
                resultText.text += name + "\n";

            // repeat request to fetch more results
            lastTableNameEvaluated = response.LastEvaluatedTableName;
        });
    }

    void UpdateTableListener()
    {
        resultText.text = ("\n*** Updating table ***\n");
        var request = new UpdateTableRequest()
        {
            TableName = @"Score",
            ProvisionedThroughput = new ProvisionedThroughput()
            {
                ReadCapacityUnits = 10,
                WriteCapacityUnits = 10
            }
        };
        Client.UpdateTableAsync(request, (result) =>
        {
            if (result.Exception != null)
            {
                resultText.text += result.Exception.Message;
                return;
            }
            var response = result.Response;
            var table = response.TableDescription;
            resultText.text += ("Table " + table.TableName + " Updated ! \n Allow a few seconds to reflect !");
        });
    }
}