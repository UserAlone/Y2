//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_true_name { get; set; }
        public string user_password { get; set; }
        public Nullable<int> rid { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
