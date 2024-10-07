﻿using NarForumUser.Client.Models.Enums;

namespace NarForumUser.Client.Models.Contact
{
    public class GetContactsWithPaginationQueryVM
    {
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public ContactTypeVM? Type { get; set; }
        public string? Subject { get; set; }

        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}