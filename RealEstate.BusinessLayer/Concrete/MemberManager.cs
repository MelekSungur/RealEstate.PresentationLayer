using RealEstate.BusinessLayer.Abstract;
using RealEstate.DataAccessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BusinessLayer.Concrete
{
    public class MemberManager : IMemberService
    {
        IMemberDal _memberdal;

        public MemberManager(IMemberDal memberdal)
        {
            _memberdal = memberdal;
        }

       

        public void TDelete(Member t)
        {
            _memberdal.Delete(t);
        }

        public Member TGetByID(int id)
        {
            return _memberdal.GetByID(id);
        }

        public List<Member> TGetList()
        {
           return _memberdal.GetList();
        }

        public void TInsert(Member t)
        {
            _memberdal.Insert(t);
        }

        public void TUpdate(Member t)
        {
            _memberdal.Update(t);
        }
    }
}
