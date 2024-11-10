using System;
using System.ComponentModel.DataAnnotations;

namespace Admin_Panel_Database_First.Models
{
    public class StudentViewModel
    {
        [Display(Name = "آیدی")]
        [Required(ErrorMessage = "فیلد {0} اجباری است!")]
        public int ID { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "فیلد {0} اجباری است!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "نام شما باید حداقل 2 و حداکثر 20 کاراکتر باشد!")]
        [RegularExpression("^[آ-ی ]+$", ErrorMessage = "فقط کاراکترهای فارسی مورد تایید است!")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "فیلد {0} اجباری است!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "نام خانوادگی شما باید حداقل 3 و حداکثر 50 کاراکتر باشد!")]
        [RegularExpression("^[آ-ی]+$", ErrorMessage = "فقط کاراکترهای فارسی مورد تایید است!")]
        public string Family { get; set; }

        [Display(Name = "سن")]
        [Range(6, 120, ErrorMessage = "سن شما نمی تواند کمتر از 6 سال باشد !")]
        public Nullable<int> Age { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "فیلد {0} اجباری است!")]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "فرمت {0} شما صحیح نیست!")]
        public string PhoneNumber { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "فیلد {0} اجباری است!")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "رمز عبور شما باید حداقل 6 و حداکثر 30 کاراکتر باشد!")]
        public string Password { get; set; }

        [Display(Name = "آدرس ایمیل")]
        [EmailAddress(ErrorMessage = "فرمت {0} شما صحیح نیست!")]
        public string Email { get; set; }

        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "فیلد {0} اجباری است!")]
        public bool Gender { get; set; }

        [Display(Name = "وضعیت تاهل")]
        public Nullable<bool> Marital { get; set; }

        [Display(Name = "تصویر پروفایل")]
        public string ImageName { get; set; }

        [Display(Name = "تاریخ عضویت")]
        [Required(ErrorMessage = "فیلد {0} اجباری است!")]
        [DisplayFormat(DataFormatString = "{0: dddd, dd MMMM yyyy}")]
        public System.DateTime RegisterDate { get; set; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فیلد {0} اجباری است!")]
        public bool Status { get; set; }
    } //by using ViewModel u ain't gonna lose your changes upon update
                                     //however u still work with the actual Model 

    [MetadataType(typeof(StudentViewModel))] //connects ViewModel to The Actual Model in Metadata way
    public partial class T_Students { } //the keyword 'partial' let this class to be connectble
}