using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAuthServiceDataAccess.Databases.DapperPostgres.SQL
{
    internal static class SqlQueries
    {
        #region accounts
        internal static readonly string InsertAccountSql =
            "INSERT INTO accounts(username, password_hash, password_salt)" +
            "VALUES(@Username, @PasswordHash, @PasswordSalt);";

        internal static readonly string SelectAllAccountSql =
            "SELECT * FROM accounts;";

        internal static readonly string SelectAccountByAccountIdSql =
            "SELECT * FROM accounts" +
            "WHERE account_id=\'@AccountId\';";

        internal static readonly string SelectAccountByUsernameSql =
            "SELECT * FROM accounts" +
            "WHERE username=\'@Username\';";

        internal static readonly string UpdateAccountSql =
            "UPDATE accounts" +
            "SET username=\'@Username\', password_hash=\'@PasswordHash\', password_salt=\'@PasswordSalt\'" +
            "WHERE account_id=\'@AccountId\';";

        internal static readonly string DeleteAccountSql =
            "DELETE FROM accounts" +
            "WHERE account_id=\'AccountId\';";
        #endregion

        #region account_claims
        internal static readonly string InsertAccountClaimSql =
            "INSERT INTO account_claims(account_id, claim_type_name, value)" +
            "VALUES(@AccountId, @ClaimTypeName, @Value);";

        internal static readonly string SelectAllAccountClaimSql =
            "SELECT * FROM account_claims;";

        internal static readonly string SelectAccountClaimByAccountIdSql =
            "SELECT * FROM account_claims" +
            "WHERE account_id=\'@AccountId\';";

        internal static readonly string SelectAccountClaimByAccountIdAndClaimTypeNameSql =
            "SELECT * FROM account_claims" +
            "WHERE account_id=\'@AccountId\' AND claim_type_name=\'@ClaimTypeName\';";

        internal static readonly string UpdateAccountClaimSql =
            "UPDATE account_claims" +
            "SET value=\'@Value\'" +
            "WHERE account_id=\'@AccountId\' AND claim_type_name=\'@ClaimTypeName\';";

        internal static readonly string DeleteAccountClaimSql =
            "DELETE FROM account_claims" +
            "WHERE account_id=\'@AccountId\' AND claim_type_name=\'@ClaimTypeName\';";
        #endregion

        #region claim_tags
        internal static readonly string InsertClaimTagSql =
            "INSERT INTO claim_tags(claim_type_name, tag_name)" +
            "VALUES(@ClaimTypeName, @TagName);";

        internal static readonly string SelectAllClaimTagSql =
            "SELECT * FROM claim_tags;";

        internal static readonly string SelectClaimTagByClaimNameSql =
            "SELECT * FROM claim_tags" +
            "WHERE claim_type_name=\'@ClaimTypeName\';";

        internal static string DeleteClaimTagSql =
            "DELETE FROM claim_tags" +
            "WHERE claim_type_name=\'@ClaimTypeName\' AND tag_name=\'@TagName\';";
        #endregion

        #region auth_tokens
        internal static readonly string InsertAuthTokenSql =
            "INSERT INTO auth_tokens(token_string, account_id)" +
            "VALUES(@TokenString, @AccountId);";

        internal static readonly string SelectAllAuthTokenSql =
            "SELECT * FROM auth_tokens;";

        internal static readonly string SelectAuthTokenByTokenStringSql =
            "SELECT * FROM auth_tokens" +
            "WHERE token_string=\'@TokenString\';";

        internal static readonly string UpdateAuthTokenSql =
            "UPDATE auth_tokens" +
            "SET last_used=\'@LastUsed\'" +
            "WHERE token_string=\'@TokenString\';";

        internal static readonly string DeleteAuthTokenSql =
            "DELETE FROM auth_tokens" +
            "WHERE token_string=\'@TokenString\';";
        #endregion

        #region claim_types
        internal static readonly string InsertClaimTypeSql =
            "INSERT INTO claim_types(claim_type_name)" +
            "VALUES(\'@ClaimTypeName\');";

        internal static readonly string SelectAllClaimTypeSql =
            "SELECT * FROM claim_types;";

        internal static readonly string SelectClaimTypeByClaimTypeName =
            "SELECT * FROM claim_types" +
            "WHERE claim_type_name=\'@ClaimTypeName\';";

        internal static readonly string DeleteClaimTypeSql =
            "DELETE FROM claim_types" +
            "WHERE claim_type_name=\'@ClaimTypeName\';";
        #endregion
    }
}
