using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaInfo.DAL
{
    public interface IUniversityRepository : IDisposable
    {
        IEnumerable<Department> GetDepartments();
        IEnumerable<Department> GetDepartmentsSorted();
        IEnumerable<Department> GetDepartmentsByName(string nameSearchString);
        void InsertDepartment(Department department);
        void DeleteDepartment(int departmentID);
        void UpdateDepartment(Department department);

        IEnumerable<User> GetProfessors();
        IEnumerable<User> GetProfessorByName( string nameSearchString);
        int InsertProfessor(User professor);
        void DeleteProfessor(int professorID);
        void UpdateProfessor(User professor);

        IEnumerable<User> GetStudents();
       // IEnumerable<User> GetStudentsSortedByStudyYears();
        IEnumerable<User> GetStudentsByName( string nameSearchString);
        void InsertStudent(User student);
        void DeleteStudent(User student);
        void UpdateStudent(User student);

        IEnumerable<Grade> GetGradesByLabId(int labId);
        IEnumerable<Grade> GetGradesByStudentId(int studentId);
        void InsertGrade(Grade grade);
        void DeleteGrade(Grade grade);

        IEnumerable<Lab> GetLabs();
        IEnumerable<Lab> GetLabsSorted();
        IEnumerable<Lab> GetLabsByName(string nameSearchString);
        void InsertLab(Lab lab);
        void DeleteLab(Lab lab);
        void UpdateLab(Lab lab);



        IEnumerable<ProfessorPerLab> GetProfessorPerLabByProfId(int profId);
        IEnumerable<ProfessorPerLab> GetProfessorPerLab();
        void UpdateProfPerLab(int profId, List<int> labsIds);
        void InsertProfPerLab(int profId, List<int> labsIds);
    }
}
