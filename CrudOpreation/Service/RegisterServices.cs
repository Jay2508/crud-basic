using CrudOpreation.Entity;
using CrudOpreation.Entity.Model;
using Microsoft.EntityFrameworkCore.Internal;
namespace CrudOpreation.Service

{
    public class RegisterServices : IRegisterServices, IDisposable
    {
        private EntityDbContext Db;

        public RegisterServices(EntityDbContext Db)
        {
            this.Db = Db;
        }

        public string Add(RegisterTbl Model)
        {
            try
            {
                var Data = Db.RegisterTbls.SingleOrDefault(M => M.Name == Model.Name);
                if (Data != null)
                {
                    return "Name All Ready Exist";
                }
                else
                {

                    Db.RegisterTbls.Add(Model);
                    int Rowcount = Db.SaveChanges();
                    if (Rowcount > 0)
                    {
                        return "Successfully Insert Your Data..";

                    }
                    else
                    {
                        return "Somthing Wrong  Database..";

                    }
                }

            }
            catch (Exception Ex)
            {

                return Ex.ToString();
            }
        }

        public string Delete(int id)
        {
            try
            {
                var Data = Db.RegisterTbls.Find(id);
                if (Data != null)
                {
                    Db.RegisterTbls.Remove(Data);
                }
                int ReturnRow = Db.SaveChanges();
                if (ReturnRow > 0)
                {
                    return "Delete Your Data...";

                }
                else
                {
                    return "Somthing Id Is Wrong.....";

                }

            }
            catch (Exception Ex)
            {

                return Ex.ToString();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public RegisterTbl Edit(int id)
        {
            try
            {
                return Db.RegisterTbls.Find(id);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<RegisterTbl> List()
        {
            try
            {
                var Data = Db.RegisterTbls.ToList();
                return Data;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public string Update(RegisterTbl Model, int id)
        {
            try
            {
                var Data = Db.RegisterTbls.Find(id);
                if (Data == null)
                {
                    return "There Is No Data.";

                }
                Data.Name = Model.Name;
                Data.Email = Model.Email;
                //Db.Entry(Data).State = System.Data.Entity.EntityState.Modified;
                int Rowcount = Db.SaveChanges();
                if (Rowcount > 0)
                {
                    return "Successfully Update Your Data";


                }
                else
                {
                    return "Somthing Wrong in Id.";

                }

            }
            catch (Exception Ex)
            {

                return Ex.ToString();
            }
        }
    }

    public interface IRegisterServices
    {
        string Add(RegisterTbl Model);
        string Update(RegisterTbl Model, int id);
        string Delete(int id);
        RegisterTbl Edit(int id);
        List<RegisterTbl> List();
    }
}
