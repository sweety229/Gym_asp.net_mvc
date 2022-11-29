using GymProjectMvc.Dal;
using GymProjectMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProjectMvc.Service
{
    public class GymService
    {
        GymDal dal = new GymDal();

        public int insertMember(GymModel gymmodels)
        {
            return dal.insertMember(gymmodels);
        }

        public List<GymModel> getMemberList()
        {
            return dal.getMemberList();
        }

        public List<GymModel> getById(string id)
        {
            return dal.getById(id);
        }

        public int UpdateMember(GymModel gymmodels)
        {
            return dal.UpdateMember(gymmodels);
        }

        public int delete(string id)
        {
            return dal.delete(id);
        }
    }
}