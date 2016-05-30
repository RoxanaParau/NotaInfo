using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace NotaInfo.DAL
{
    public class UniversityRepository : IDisposable, IUniversityRepository
    {
        private UniversityEntities context = new UniversityEntities();
        public UniversityRepository()
        {

        }


        public IEnumerable<Department> GetDepartments()
        {
            return context.Department.OrderBy(d => d.Name).ToList();
        }

        public IEnumerable<Department> GetDepartmentsSorted()
        {

            return context.Department.Include("StudyYears").OrderBy(d => d.StudyYears).ToList();
        }

        public IEnumerable<Department> GetDepartmentsByName(string nameSearchString)
        {
            if (String.IsNullOrWhiteSpace(nameSearchString))
            {
                nameSearchString = "";
            }
            return context.Department.Include("StudyYears").OrderBy(d => d.Name).Where(d => d.Name.Contains(nameSearchString)).ToList();
        }

        public void InsertDepartment(Department department)
        {
            try
            {
                department.DepartmentID = GenerateDepartmentID();
                context.Department.Add(department);
                context.SaveChanges();
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
                Department department = context.Department.Where(d => d.DepartmentID == departmentID).FirstOrDefault();
                context.Department.Attach(department);
                context.Department.Remove(department);
                context.SaveChanges();
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
                Department oldDepartment = context.Department.Where(d => d.DepartmentID == department.DepartmentID).FirstOrDefault();
                if (oldDepartment == null) return;

                oldDepartment.Administrator = department.Administrator;
                oldDepartment.Budget = department.Budget;
                oldDepartment.Name = department.Name;
                oldDepartment.StartDate = department.StartDate;
                oldDepartment.StudyYears = department.StudyYears;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public IEnumerable<User> GetProfessors()
        {
            int professorRoleID = context.Roles.Where(r => r.Name == "professor").FirstOrDefault().RoleID;
            return context.Users1.Where(u => u.RoleId == professorRoleID).OrderBy(d => d.LastName).ToList();
        }

        public IEnumerable<User> GetProfessorByName(string nameSearchString)
        {
            int professorRoleID = context.Roles.Where(r => r.Name == "professor").FirstOrDefault().RoleID;
            if (context.Users1.Where(p => (p.LastName.Contains(nameSearchString) || p.FirstName.Contains(nameSearchString)) && p.RoleId == professorRoleID) == null) return null;
            return context.Users1.Where(p => (p.LastName.Contains(nameSearchString) || p.FirstName.Contains(nameSearchString)) && p.RoleId == professorRoleID).OrderBy(p => p.LastName);
        }

        public void InsertProfessor(User professor)
        {
            try
            {
                int professorRoleID = context.Roles.Where(r => r.Name == "professor").FirstOrDefault().RoleID;
                professor.RoleId = professorRoleID;
                context.Users1.Add(professor);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void DeleteProfessor(User professor)
        {
            try
            {
                context.Users1.Attach(professor);
                context.Users1.Remove(professor);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void UpdateProfessor(User professor)
        {
            try
            {
                User prof = context.Users1.Where(d => d.UserID == professor.UserID).FirstOrDefault();
                if (prof == null) return;

                prof.Username = professor.Username;
                prof.EnrollmentDate = professor.EnrollmentDate;
                prof.FirstName = professor.FirstName;
                prof.HireDate = professor.HireDate;
                prof.LastName = professor.LastName;
                prof.Password = professor.Password;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        //public IEnumerable<User> GetStudentsSortedByStudyYears()
        //{

        //}

        public IEnumerable<User> GetStudents()
        {
            int studentRoleID = context.Roles.Where(u => u.Name == "student").FirstOrDefault().RoleID;
            return context.Users1.Where(u => u.RoleId == studentRoleID).OrderBy(s => s.LastName);
        }

        public IEnumerable<User> GetStudentsByName(string nameSearchString)
        {
            int studentRoleID = context.Roles.Where(u => u.Name == "student").FirstOrDefault().RoleID;
            return context.Users1.Where(u => u.RoleId == studentRoleID).OrderBy(s => s.LastName.Contains(nameSearchString) || s.FirstName.Contains(nameSearchString)) != null ?
                context.Users1.Where(u => u.RoleId == studentRoleID).OrderBy(s => s.LastName.Contains(nameSearchString) || s.FirstName.Contains(nameSearchString)).OrderBy(u => u.LastName) : null;
        }

        public void InsertStudent(User student)
        {
            try
            {
                int studentRoleID = context.Roles.Where(r => r.Name == "student").FirstOrDefault().RoleID;
                student.RoleId = studentRoleID;
                context.Users1.Add(student);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void DeleteStudent(User student)
        {
            try
            {
                context.Users1.Attach(student);
                context.Users1.Remove(student);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void UpdateStudent(User student)
        {
            try
            {
                User oldValues = context.Users1.Where(d => d.UserID == student.UserID).FirstOrDefault();
                if (oldValues == null) return;

                oldValues.Username = student.Username;
                oldValues.EnrollmentDate = student.EnrollmentDate;
                oldValues.FirstName = student.FirstName;
                oldValues.HireDate = student.HireDate;
                oldValues.LastName = student.LastName;
                oldValues.Password = student.Password;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public IEnumerable<Grade> GetGradesByLabId(int labId)
        {
            return context.Grades.Where(g => g.LabId == labId);
        }

        public IEnumerable<Grade> GetGradesByStudentId(int studentId)
        {
            return context.Grades.Where(g => g.StudentId == studentId);
        }

        public void InsertGrade(Grade grade)
        {
            try
            {
                context.Grades.Attach(grade);
                context.Grades.Add(grade);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void DeleteGrade(Grade grade)
        {
            try
            {
                context.Grades.Attach(grade);
                context.Grades.Remove(grade);
                context.SaveChanges();
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
                    context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public IEnumerable<Lab> GetLabs()
        {
            return context.Labs.OrderBy(l => l.Name);
        }

        public IEnumerable<Lab> GetLabsSorted()
        {
            return context.Labs.OrderBy(l => l.StudyYear.YearOfStudy);
        }

        public IEnumerable<Lab> GetLabsByName(string nameSearchString)
        {
            return context.Labs.Where(l => l.Name.Contains(nameSearchString));
        }

        public void InsertLab(Lab lab)
        {
            try
            {
              
                context.Labs.Add(lab);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void DeleteLab(Lab lab)
        {
            try
            {
                context.Labs.Attach(lab);
                context.Labs.Remove(lab);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void UpdateLab(Lab lab)
        {
            try
            {
                Lab oldValues = context.Labs.Where(l => l.Id == lab.Id).FirstOrDefault();
                oldValues.Name = lab.Name;
                oldValues.ProfessorPerLabs = lab.ProfessorPerLabs;
                oldValues.StudyYear = lab.StudyYear;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        #region Private Methods
        private Int32 GenerateDepartmentID()
        {
            Int32 maxDepartmentID = 0;
            var department = (from d in GetDepartments()
                              orderby d.DepartmentID descending
                              select d).FirstOrDefault();
            if (department != null)
            {
                maxDepartmentID = department.DepartmentID + 1;
            }
            return maxDepartmentID;
        }

        #endregion

    }
}