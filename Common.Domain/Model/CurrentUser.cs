using Common.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model
{

    public class CurrentUser
    {

        private string _token;
        private IDictionary<string, object> _claims;

        public CurrentUser()
        {
            this._claims = new Dictionary<string, object>();
        }

        public CurrentUser Init(string token, IDictionary<string, object> claims)
        {
            this._token = token;
            this._claims = claims;
            return this;
        }

        public string GetToken()
        {
            return this._token;
        }

        public IDictionary<string, object> GetClaims()
        {
            return this._claims;
        }

        public string GetRole()
        {
            var typeRole = this._claims.Where(_ => _.Key == "role");
            if (typeRole.IsAny())
                return typeRole.SingleOrDefault().Value.ToString();
            return string.Empty;
        }

        public string GetTypeRole()
        {
            var typeRole = this._claims.Where(_ => _.Key == "typerole");
            if (typeRole.IsAny())
                return typeRole.SingleOrDefault().Value.ToString();
            return string.Empty;
        }

        public bool IsAdmin()
        {
            if (this._claims.IsNotNull())
            {
                return this._claims
                    .Where(_ => _.Key.ToLower() == "typerole")
                    .Where(_ => _.Value.ToString() == "admin").IsAny();
            }
            return false;
        }

        public bool IsTenant()
        {
            if (this._claims.IsNotNull())
            {
                return this._claims
                    .Where(_ => _.Key.ToLower() == "typerole")
                    .Where(_ => _.Value.ToString() == "tenant").IsAny();
            }
            return false;
        }

        public bool IsTypeTeam()
        {
            if (this._claims.IsNotNull())
            {
                return this._claims
                    .Where(_ => _.Key.ToLower() == "typerole")
                    .Where(_ => _.Value.ToString() == "Team").IsAny();
            }
            return false;
        }

        public bool IsTypeFollower()
        {
            if (this._claims.IsNotNull())
            {
                return this._claims
                    .Where(_ => _.Key.ToLower() == "typerole")
                    .Where(_ => _.Value.ToString() == "Follower").IsAny();
            }
            return false;
        }

        public bool IsTypeCompany()
        {
            if (this._claims.IsNotNull())
            {
                return this._claims
                    .Where(_ => _.Key.ToLower() == "typerole")
                    .Where(_ => _.Value.ToString() == "Company").IsAny();
            }
            return false;
        }

        public bool IsTypeStardart()
        {
            if (this._claims.IsNotNull())
            {
                return this._claims
                    .Where(_ => _.Key.ToLower() == "typerole")
                    .Where(_ => _.Value.ToString() == "Standart").IsAny();
            }
            return false;
        }


        public TS GetTenantId<TS>()
        {
            if (this.IsTenant())
            {
                var subjectId = this._claims
                    .Where(_ => _.Key.ToLower() == "sub" || _.Key.ToLower() == "client_sub")
                    .SingleOrDefault()
                    .Value;

                return (TS)Convert.ChangeType(subjectId, typeof(TS));
            }
            return default(TS);
        }

        public TS GetTenantOwnerId<TS>()
        {
            if (this.IsTenant())
            {
                var subjectId = this._claims
                    .Where(_ => _.Key.ToLower() == "owner")
                    .SingleOrDefault()
                    .Value;

                return (TS)Convert.ChangeType(subjectId, typeof(TS));
            }
            return default(TS);
        }

        public TS GetSubjectId<TS>()
        {
            if (this._claims.IsAny())
            {
                var subjectId = this._claims
                    .Where(_ => _.Key.ToLower() == "sub" || _.Key.ToLower() == "client_sub")
                    .SingleOrDefault()
                    .Value;

                return (TS)Convert.ChangeType(subjectId, typeof(TS));
            }

            return default(TS);
        }

        public TS GetTenantClientId<TS>()
        {
            if (this.IsTypeFollower())
            {
                var clientId = this._claims
                    .Where(_ => _.Key.ToLower() == "clientid")
                    .SingleOrDefault()
                    .Value;

                return (TS)Convert.ChangeType(clientId, typeof(TS));
            }
            return default(TS);
        }

        public TS GetClaimByName<TS>(string name)
        {
            var claim_ = this._claims
                .Where(_ => _.Key.ToLower() == name.ToLower());

            if (claim_.IsNotAny())
                return default(TS);

            var claim = claim_.SingleOrDefault().Value;
            return (TS)Convert.ChangeType(claim, typeof(TS));
        }

    }
}
