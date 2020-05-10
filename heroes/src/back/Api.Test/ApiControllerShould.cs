using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Controllers;
using Api.Model;
using Api.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace Api.Test
{
    public class ApiControllerShould
    {
        [Fact]
        public async Task get_all_heros()
        {
            var repository = Substitute.For<IHeroesRepository>();
            repository.GetAllAsync().Returns(TestHeros.AllHeros().ToList());

            var herosController = new HeroesController(repository);
            var actionResult = await herosController.Get();

            ((actionResult.Result as OkObjectResult).Value as IEnumerable<Hero>).Should().HaveCount(TestHeros.AllHeros().Length);
        }

        [Fact]
        public async Task return_status_ok_getting_all_heros()
        {
            var repository = Substitute.For<IHeroesRepository>();
            repository.GetAllAsync().Returns(TestHeros.AllHeros().ToList());

            var herosController = new HeroesController(repository);
            var result = await herosController.Get();
            (result.Result as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task get_hero()
        {
            var hero = TestHeros.AllHeros().First();
            var repository = Substitute.For<IHeroesRepository>();
            repository.GetByIdAsync(hero.Id).Returns(hero);

            var herosController = new HeroesController(repository);
            var result = await herosController.Get(hero.Id);

            ((result.Result as OkObjectResult).Value as Hero).Should().Be(hero);
        }

        [Fact]
        public async Task return_status_ok_getting_one_hero()
        {
            var hero = TestHeros.AllHeros().First();
            var repository = Substitute.For<IHeroesRepository>();
            repository.GetByIdAsync(hero.Id).Returns(hero);

            var herosController = new HeroesController(repository);
            var result = await herosController.Get(hero.Id);
            (result.Result as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task get_status_not_found_updating_a_non_existent_hero()
        {
            var hero = new Hero()
            {
                Id = Guid.NewGuid(),
                Name="name",
                Likes = 2,
                Default = true,
                AlterEgo = "alter",
                AvatarUrl = "avaratrurl",
                AvatarThumbnailUrl = "avaratrurl2"
            };
            var repository = Substitute.For<IHeroesRepository>();
            repository.GetByIdAsync(hero.Id).Returns((Hero)null);

            var herosController = new HeroesController(repository);
            var result = await herosController.Put(hero);

            (result as NotFoundResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task get_status_not_found_deleting_a_non_existent_hero()
        {
            var hero = new Hero()
            {
                Id = Guid.NewGuid()
            };
            var repository = Substitute.For<IHeroesRepository>();
            repository.GetByIdAsync(hero.Id).Returns((Hero)null);

            var herosController = new HeroesController(repository);
            var result = await herosController.Delete(hero.Id);

            (result as NotFoundResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task get_status_bad_request_creating_a_hero_with_no_id()
        {
            var hero = new Hero()
            {
                Name = "name",
                Likes = 2,
                Default = true,
                AlterEgo = "alter",
                AvatarUrl = "avaratrurl",
                AvatarThumbnailUrl = "avaratrurl2"
            };
            var repository = Substitute.For<IHeroesRepository>();

            var herosController = new HeroesController(repository);
            var result = await herosController.Post(hero);
            (result as BadRequestResult).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task get_status_bad_request_creating_a_hero_with_no_name()
        {
            var hero = new Hero()
            {
                Id = Guid.NewGuid(),
                Likes = 2,
                Default = true,
                AlterEgo = "alter",
                AvatarUrl = "avaratrurl",
                AvatarThumbnailUrl = "avaratrurl2"
            };
            var repository = Substitute.For<IHeroesRepository>();

            var herosController = new HeroesController(repository);
            var result = await herosController.Post(hero);
            (result as BadRequestResult).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task get_status_bad_request_creating_a_hero_with_no_alterego()
        {
            var hero = new Hero()
            {
                Id = Guid.NewGuid(),
                Name = "name",
                Likes = 2,
                Default = true,
                AvatarUrl = "avaratrurl",
                AvatarThumbnailUrl = "avaratrurl2"

            };
            var repository = Substitute.For<IHeroesRepository>();

            var herosController = new HeroesController(repository);
            var result = await herosController.Post(hero);
            (result as BadRequestResult).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task get_status_bad_request_creating_a_hero_with_negative_likes()
        {
            var hero = new Hero()
            {
                Id = Guid.NewGuid(),
                Name = "name",
                Likes = -2,
                Default = true,
                AlterEgo = "alter",
                AvatarUrl = "avaratrurl",
                AvatarThumbnailUrl = "avaratrurl2"

            };
            var repository = Substitute.For<IHeroesRepository>();

            var herosController = new HeroesController(repository);
            var result = await herosController.Post(hero);
            (result as BadRequestResult).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }
    }
}