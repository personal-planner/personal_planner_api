using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class UserModel: IdentityUser
    {
        public UserModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public override string Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
        public virtual IEnumerable<ActModel> Acts { get; set; }
        public virtual IEnumerable<CategoryModel> Categories { get; set; }
        //public virtual IEnumerable<RefreshToken> RefreshTokens { get; set; }
    }
}
 