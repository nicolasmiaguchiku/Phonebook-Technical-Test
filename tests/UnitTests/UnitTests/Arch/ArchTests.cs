using FluentAssertions;
using NetArchTest.Rules;

namespace Phonebook.Tests.UnitTests.Arch
{
    public class ArchTests()
    {
        [Fact]
        public void PhonebookApplicationLayerShoudNotToDepentToCroosCuttingAndInfrastructureAndApi()
        {
            //Pegar o assembly
            var assembly = typeof(Application.Input.Handlers.Commands.AddContactCommand).Assembly;

            //Verificar se tem dependência com a CroosCutting, Infrastructure e Api
            var result = Types.InAssembly(assembly)
                .Should()
                .NotHaveDependencyOn("Phonebook.CrossCutting")
                .And()
                .NotHaveDependencyOn("Phonebook.Infrastructure")
                .And()
                .NotHaveDependencyOn("Phonebook.WebApi")
                .GetResult();


            //Verificar se é result é verdadeiro
            result.IsSuccessful
                .Should()
                .BeTrue();
        }

        [Fact]
        public void PhonebokDomainLayerShoudNotToDepentOthersProjects()
        {
            //Pegar o assembly
            var assembly = typeof(Domain.Interfaces.IContactRepository).Assembly;

            //Verificar se tem dependência com outro assemblys
            var result = Types.InAssembly(assembly)
                .Should()
                .NotHaveDependencyOn("Phonebook.Infrastructure")
                .And()
                .NotHaveDependencyOn("Phonebook.Application")
                .And()
                .NotHaveDependencyOn("Phonebook.CrossCutting")
                .And()
                .NotHaveDependencyOn("Phonebook.WebApi")
                .GetResult();

            //Verificar se é result é verdadeiro
            result.IsSuccessful
                .Should()
                .BeTrue();
        }

        [Fact]
        public void PhonebookCrossCuttingsLayerSoudNotDepedentToApi()
        {
            var assembly = typeof(CrossCutting.Models.Settings).Assembly;

            var result = Types.InAssembly(assembly)
                .Should()
                .NotHaveDependencyOn("Phonebook.WebApi")
                .GetResult();

            result.IsSuccessful
                .Should()
                .BeTrue();
        }

        [Fact]
        public void PhoneboookInfrastructurelayerShouddNotToDedpendentDomainAndCrossCutting()
        {
            var assembly = typeof(Infrastructure.Mappers.ContactMapper).Assembly;

            var result = Types.InAssembly(assembly)
                .Should()
                .NotHaveDependencyOn("Phonebook.WebApi")
                .And()
                .NotHaveDependencyOn("Phonebook.CrossCutting")
                .GetResult();

            result.IsSuccessful
                .Should()
                .BeTrue();
        }

        [Fact]
        public void PhonebookWebApiLayerShouldNotToDependentDomainAndInfrastructure()
        {
            var assembly = typeof(WebApi.Controllers.PhonebookCommandController).Assembly;

            var result = Types.InAssembly(assembly)
                .That()
                .DoNotResideInNamespace("Phonebook.CrossCutting")
                .Should()
                .NotHaveDependencyOn("Phonebook.Domain")
                .And()
                .NotHaveDependencyOn("Phonebook.Infrastructure")
                .GetResult();

            result.IsSuccessful
                .Should()
                .BeTrue();
        }
    }
}
