namespace WPFTest.Infraestructure.Common
{
    public class CommonEnums
    {
    }

    public enum MessageType
    {
        High,
        Medium,
        Monitorable,
        None,
        Unexpected,
        Expected,
        Verbose,
        VerboseEx,
        Debug,
        DB_High,
        DB_Medium,
        DB_Monitorable,
        DB_None,
        DB_Unexpected,
        DB_Expected,
        DB_Verbose,
        DB_VerboseEx,
        DB_Debug,
        EF_High,
        EF_Medium,
        EF_Monitorable,
        EF_None,
        EF_Unexpected,
        EF_Expected,
        EF_Verbose,
        EF_VerboseEx,
        EF_Debug,
        Email_Unexpected,
        Email_Expected,
        Email_Monitorable,
        Login_Monitorable,
        Login_Unexpected,
        Login_Expected
    }


    public enum TraceSeverity
    {
        High = 20,
        Medium = 50,
        Monitorable = 15,
        None = 0,
        Unexpected = 10,
        Verbose = 100,
        VerboseEx = 200
    }
}
