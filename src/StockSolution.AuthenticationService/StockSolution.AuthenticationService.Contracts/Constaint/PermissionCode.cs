using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Contracts.Constaint
{
    public static class PermissionCode
    {
        public const string UserCreate = "user.create";
        public const string UserRead = "user.read";
        public const string UserUpdate = "user.update";
        public const string UserDelete = "user.delete";
        public const string RoleCreate = "role.create";
        public const string RoleRead = "role.read";
        public const string RoleUpdate = "role.update";
        public const string RoleDelete = "role.delete";
        public const string StockBuy = "stock.buy";
        public const string StockSell = "stock.sell";
        public const string WalletView = "wallet.view";
        public const string WalletDeposit = "wallet.deposit";

    }
}
