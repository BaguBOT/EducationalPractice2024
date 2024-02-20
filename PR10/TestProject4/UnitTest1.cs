using Avalonia;
using MySqlConnector;
using YPISPRO41.Class2;
using PR10;
namespace TestProject4;

public class UnitTest1
{
    private string _connectserv = "server=localhost;uid=User;" +
                                  "database=yp;" +
                                  "password=123456;";
    [Fact]
    public void TestCAPCTH_2()
    {
        var expected = true;
        Test testCAPCTH = new Test();
        var actual = testCAPCTH.TestCAPCHA(1111);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestCAPCTH_1()
    {
        var expected = true;
        Test testCAPCTH = new Test();
        var actual = testCAPCTH.TestCAPCHA(2222);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestCAPCTH_3()
    {
        var expected = true;
        Test testCAPCTH = new Test();
        var actual = testCAPCTH.TestCAPCHA(3333);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestCAPCTH_4()
    {
        var expected = true;
        Test testCAPCTH = new Test();
        var actual = testCAPCTH.TestCAPCHA(4444);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestCAPCTH_5()
    {
        var expected = true;
        Test testCAPCTH = new Test();
        var actual = testCAPCTH.TestCAPCHA(5555);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestConnectserv()
    {
        var connection = new MySqlConnection(_connectserv);
        connection.Open();
        Assert.Equal(System.Data.ConnectionState.Open,connection.State);
        connection.Close();
    }
    [Fact]
    public void TestSizeMain()
    {
        var expected = false;
        Test TestClass= new Test();
        var actual = TestClass.CheckSize(555, 430);
        Assert.Equal(expected,actual);
    }
    [Fact]
    public void TestSizeGest()
    {
        var expected = false;
        Test TestClass= new Test();
        var actual = TestClass.CheckSize(1000, 500);
        Assert.Equal(expected,actual);
    }
    [Fact]
    public void TestShowtabel()
    {
        var expected = true;
        Test TestClass= new Test();
        var actual = TestClass.ShowTable();
        Assert.Equal(expected,actual);
    }
    [Fact]
    public void TestAdd()
    {
        var expected = true;
        int num1 = 1;
        int num2 = 1;
        int num3= 1;
        int num4= 1;
        int num5= 1;
        int num6= 1;
        int num7= 1;
        int num8= 1;
        string vales1= "A";
        string vales2=  "A";
        string vales3=  "A";
        Test TestClass= new Test();
        var actual = TestClass.ShowTable();
        Assert.Equal(expected,actual);
    }
}