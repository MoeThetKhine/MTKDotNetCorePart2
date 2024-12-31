namespace MTKDotNetCorePart2.WindowFormsApp.Queries
{
    public class BlogQuery
    {
        public static string BlogCreate { get; } = @"INSERT INTO [dbo].[Tbl_Blog]
            ([BlogTitle]
            ,[BlogAuthor]
            ,[BlogContent])
        VALUES
            (@BlogTitle
            ,@BlogAuthor
            ,@BlogContent)";

        public static string BlogList { get; } = @"SELECT [BlogId]
        ,[BlogTitle]
        ,[BlogAuthor]
        ,[BlogContent]
FROM [dbo].[Tbl_Blog]";
            
    }


}


