using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class UserModel: IdentityUser<Guid>
    {
        public UserModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public override Guid Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
        public virtual IEnumerable<ActModel> Acts { get; set; }
        public virtual IEnumerable<CategoryModel> Categories { get; set; }
    }
}
 