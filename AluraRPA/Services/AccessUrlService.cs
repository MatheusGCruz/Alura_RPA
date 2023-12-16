using AluraRPA.DAL;
using AluraRPA.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.Services
{
    internal class AccessUrlService
    {
        AccessUrlDAL accessUrlDAL = new AccessUrlDAL();



        public int isValidUrl()
        {
            return 0;
        }

        public bool tryAccess(string tryedUrl)
        {
            int accessUrlId = 0;

            AccessUrlDbo accessUrlDbo = new AccessUrlDbo(tryedUrl);

            accessUrlDbo =  accessUrlDAL.getAccessUrl(accessUrlDbo);



            return (accessUrlDbo.acessUrlId > 0 && accessUrlDbo.validUrl ==1);
        }

        public bool updateUrlData(AccessUrlDbo accessUrlDbo)
        {

            return accessUrlDAL.updateAccessUrl(accessUrlDbo);
        }
    }
}
