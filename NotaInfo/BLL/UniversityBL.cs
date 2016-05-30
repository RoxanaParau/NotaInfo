using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotaInfo.DAL;

namespace NotaInfo.BLL
{
    public class UniversityBL : IDisposable
    {
        private IUniversityRepository universityRepository;

        public UniversityBL()
        {
            this.universityRepository = new UniversityRepository();
        }

        public UniversityBL(IUniversityRepository universityRepository)
        {
            this.universityRepository = universityRepository;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return universityRepository.GetDepartments();
        }

        public IEnumerable<Department> GetDepartmentsByName(string nameSearchString)
        {
            return universityRepository.GetDepartmentsByName(nameSearchString);
        }
        
        public void InsertDepartment(Department department)
        {
         
            try
            {
                universityRepository.InsertDepartment(department);
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void DeleteDepartment(int departmentID)
        {
            try
            {
                universityRepository.DeleteDepartment(departmentID);
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void UpdateDepartment(Department department)
        {
            
            try
            {
                universityRepository.UpdateDepartment(department);
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }

        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    universityRepository.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}