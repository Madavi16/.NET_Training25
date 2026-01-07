using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_frist_Demo
{
    [Table("MyEmployee")]
    public class EmployeeEf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage ="Please enter the valid employee id ")]
        [RegularExpression("^E[0-9]{3}$",ErrorMessage ="Employee Id should start from E following by 3 digits")]

        [Column("EmpId",TypeName ="varchar")]
        [MaxLength(10)]
        public string EmpId { get; set; }


        [Required(ErrorMessage ="Employee name is required")]
        [MaxLength(20)]
        public string EmpName { get; set; }

        [Required(ErrorMessage ="Department Name is required")]
        [Column("DeptName", TypeName = "varchar")]
        [MaxLength(30)]
        public string DepartmentName { get; set; }

        [Range(5000,50000,ErrorMessage ="Salary must be between 5000 and 50000")] 
        public int Salary { get; set; }

        [Range(1900,2100,ErrorMessage ="Year of joining must be >=1900 and <=2100")]

        public int YearOfJoining { get; set; }
    }
}
