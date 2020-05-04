using System;

namespace Api.Model
{
    public class Hero
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AlterEgo { get; set; }
        public bool Default { get; set; }
        public int Likes { get; set; }
        public string AvatarUrl { get; set; }
        public string AvatarThumbnailUrl { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name)
                   && !string.IsNullOrWhiteSpace(AlterEgo)
                   && Likes >= 0
                   && Id != Guid.Empty;
        }
    }
}