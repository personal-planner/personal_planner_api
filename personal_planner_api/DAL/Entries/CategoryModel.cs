﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public string ColorCode { get; set; }
        public virtual IEnumerable<ActModel> Acts { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserModel User { get; set; }
    }
}
