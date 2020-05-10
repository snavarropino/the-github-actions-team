using System;
using System.Collections.Generic;
using System.Text;
using Api.Model;

namespace Api.Test
{
    public static class TestHeros
    {
        public static Hero[] AllHeros()
        {
            return new Hero[]
                {
                    new Hero ()
                    {
                        Name="Thor",
                        AlterEgo="Donald Blake",
                        AvatarUrl="https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2Fo0OFH4ddtfekOwK3ZKds.jpg?alt=media&token=7cdac0a0-ac21-4203-943e-1cabe0c71f4c",
                        AvatarThumbnailUrl="https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2Fo0OFH4ddtfekOwK3ZKds-thumbnail.jpeg?alt=media&token=c39680fe-be8a-408f-89aa-bc4a2fd99ce7",
                        Default=true,
                        Likes=17
                    },
                    new Hero ()
                    {
                        Name="Spiderman",
                        AlterEgo="Peter Parker",
                        AvatarUrl="https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2FcFiPzbhKt1zVVThrb9EH.jpg?alt=media&token=35d1cdd9-f1f2-416b-90d4-6bcba2e72305",
                        AvatarThumbnailUrl="https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2FcFiPzbhKt1zVVThrb9EH-thumbnail.jpg?alt=media&token=dbdcd583-1851-46ad-bd23-df68ca37467e",
                        Default=true,
                        Likes=78
                    },
                    new Hero ()
                    {
                        Name="Wonder Woman",
                        AlterEgo="Diana Prince",
                        AvatarUrl="https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2Fz6jX346az6e6QifVj1Yd.jpg?alt=media&token=3cbe10ed-590f-4ca6-b088-0f927d53730d",
                        AvatarThumbnailUrl="https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2Fz6jX346az6e6QifVj1Yd-thumbnail.jpg?alt=media&token=bbd1720c-9003-4119-bb72-c0bc03b6412c",
                        Default=true,
                        Likes=7
                    },
                    new Hero ()
                    {
                        Name="Hulk",
                        AlterEgo="Bruce Banner",
                        AvatarUrl="https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2FVajTPSd8NLy2bxGXydY4.jpg?alt=media&token=6d8ab120-fd53-4af0-9069-1c97390f26bf",
                        AvatarThumbnailUrl="https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2FVajTPSd8NLy2bxGXydY4-thumbnail.jpg?alt=media&token=cec325f7-0e90-4565-b6d4-754cf58614fb",
                        Default=false,
                        Likes=7
                    }
                };
        }
    }
}
