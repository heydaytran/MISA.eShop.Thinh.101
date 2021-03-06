using Dapper;
using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces;
using MISA.EShop.Core.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MISA.EShop.Infrastructure.Repository
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {

        public int GetCountStores()
        {
            var storeName = $"Proc_GetCountStores";
            var total = _dbConnection
                .Execute(storeName, commandType: CommandType.StoredProcedure);
            return total;
        }

        public Store GetStoreByStoreCode(string storeCode)
        {
            var storeName = $"Proc_GetStoreByStoreCode";
            var parameters = new DynamicParameters();
            parameters.Add("@StoreCode", storeCode);
            var store = _dbConnection
                .Query<Store>(storeName, parameters, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            return store;
        }

        public IEnumerable<Store> GetStoreFilter(
            string storeCode,
            string storeName,
            string address,
            string phoneNumber,
            int? status,
            int recordNumber,
            int pageNumber)
        {
            //var procName = $"Proc_GetStoreFilter";
            //var parameters = new DynamicParameters();
            //parameters.Add("@StoreCode", storeCode);
            //parameters.Add("@StoreName", storeName);
            //parameters.Add("@Address", address);
            //parameters.Add("@PhoneNumber", phoneNumber);
            //parameters.Add("@Status", status);

            storeCode = storeCode != null ? storeCode : string.Empty;
            storeName = storeName != null ? storeName : string.Empty;
            address = address != null ? address : string.Empty;
            status = status != null ? status : 0;
            phoneNumber = phoneNumber != null ? phoneNumber : string.Empty;

            var query = "SELECT * FROM Store WHERE StoreName LIKE '%" + storeName + "%' " +
                "and  StoreCode LIKE '%" + storeCode + "%' " +
                "and  Address LIKE '%" + address + "%'" +
                "and  Status = " + status +
                " and  PhoneNumber LIKE '%" + phoneNumber + "%'";

            var stores = _dbConnection
                .Query<Store>(query, commandType: CommandType.Text).OrderByDescending(s => s.CreatedDate).ToList();

            return stores;
        }

        public IEnumerable<Store> GetStoreByIndexOffset(int positionStart, int offset)
        {
            var procName = $"GetStoreByIndexOffset";
            var parameters = new DynamicParameters();
            parameters.Add("positionStart", positionStart);
            parameters.Add("offset", offset);
            var entities = _dbConnection.Query<Store>(procName, param: parameters, commandType: CommandType.StoredProcedure);
            return entities;
        }

        //public EntittiesPaging<Store> GetStorePaging(int pageSize, int pageIndex)
        //{
        //    var entitiesPaging = new EntittiesPaging<Store>();
        //    var procName = "Proc_GetStorePaging";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@PageSize", pageSize);
        //    parameters.Add("@PageIndex", pageIndex);
        //    parameters.Add("@TotalRecord", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
        //    parameters.Add("@TotalPage", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

        //    var listStore = _dbConnection.Query<Store>(procName, parameters, commandType: CommandType.StoredProcedure);
        //    entitiesPaging.Data = listStore.ToList();
        //    entitiesPaging.TotalRecord = parameters.Get<int>("@TotaRecord");
        //    entitiesPaging.TotalPage = parameters.Get<int>("@TotalPage");

        //    return entitiesPaging;
        //}


        public bool CheckStoreCode(Guid? storeId, string storeCode, string functionName)
        {
            var sqlCheckExistCode = "";
            if (functionName == "Insert")
            {
                // Thực hiện lấy số lượng bản ghi có mã khách hàng trùng với mã khách hàng truyền vào
                sqlCheckExistCode = $"Select StoreCode from Store where Store.StoreCode = @StoreCode";
            }
            else if (functionName == "Update")
            {
                // Thực hiện lấy số lượng bản ghi có mã khách hàng trùng với mã khách hàng truyền vào, loại bỏ bản ghi hiện tại
                sqlCheckExistCode = $"Select StoreCode from Store where Store.StoreCode = @StoreCode and  Store.StoreId != '{storeId}'";
            }

            // truyền vào tham số mã cửa hàng - storeCode
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@StoreCode", storeCode);

            // thực hiện truy vấn 
            var storeExistCode = _dbConnection
                .Query<string>(
                    sqlCheckExistCode,
                    dynamicParameters,
                    commandType: CommandType.Text);

            // kiểm tra kết quả:
            if (storeExistCode.AsList().Count > 0)
            {
                return true;
            }

            return false;
        }


    }
}
