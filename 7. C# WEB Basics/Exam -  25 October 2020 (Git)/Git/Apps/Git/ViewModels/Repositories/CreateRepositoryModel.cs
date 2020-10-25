using System;

namespace Git.ViewModels.Repositories
{
    public class CreateRepositoryModel
    {
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        public string OwnerId { get; set; }
       

    }
}
