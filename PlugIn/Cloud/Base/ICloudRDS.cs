using System.Collections.Generic;

namespace Auu.PlugIn.Cloud.Base
{
    public interface ICloudRds
    {
        void CreateDatabase(string dbInstanceId, string dbName, string dbDesc, string adminAccount);
        string DeleteDatabase(string dbInstanceId, string dbName);
        int GetDatabaseCountByInstanceId(string dbInstanceId);
        string GetDbStatus(string dbInstanceId, string dbName);
        IEnumerable<string> DescribeRegions();
        IEnumerable<string> GetDbInstances(string regionId);
        bool GrantAccountPrivilege(string dbInstanceId, string dbName, string accountName);
    }
}