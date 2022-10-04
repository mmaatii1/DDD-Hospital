using AutoFixture.Xunit2;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;
using PatientManagement.Data;
using AutoFixture;
using FluentAssertions;
using PatientManagement.Core.Validators.Exceptions;
using Ardalis.Specification;
using System.Security.AccessControl;


namespace PatientManagement.UnitTests
{
    public class RepositoryTests
    {
        private readonly PatientManagementContext _dbContext;

        public RepositoryTests()
        {
            var dbOptions = new DbContextOptionsBuilder<PatientManagementContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            _dbContext = new PatientManagementContext(dbOptions.Options);
        }
        [Theory]
        [AutoData]
        public async Task GetByIdAsync_ShouldReturnsEntityWithTheSameValues(Patient expected)
        {
            //Arrange
            await _dbContext.AddAsync(expected);
            await _dbContext.SaveChangesAsync();

            var sut = new GenericRepository<Patient>(_dbContext);

            //Act
            var actual = await sut.GetByIdAsync(expected.Id);

            //Assert
            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [AutoData]
        [Theory]
        public async Task GetAllAsync_ShouldReturnsAllEntitiesWithTheSameValues(Patient expected1, Patient expected2)
        { 
            //Arrange
           await _dbContext.AddAsync(expected1);
           await _dbContext.AddAsync(expected2);
           await _dbContext.SaveChangesAsync();
           
           var expectedList = new List<Patient>();
           expectedList.Add(expected1);
           expectedList.Add(expected2);

           var sut = new GenericRepository<Patient>(_dbContext);
           //Act
           
           var actual = await sut.GetAllAsync();
           //Assert

           actual.Should().NotBeEmpty();
           actual.Should().BeEquivalentTo(expectedList);
        }
        [AutoData]
        [Theory]
        public async Task DeleteAsync_ShouldThrowEntityNotFoundException_WhenGivenEntityThatDoesentExists_And_ShouldReturnDeletedEntityWhenItExists(Patient expected1)
        {
            //Arrange
            await _dbContext.AddAsync(expected1);
            var sut = new GenericRepository<Patient>(_dbContext);
            //Act
            var actual = await sut.DeleteAsync(expected1.Id);
            //Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => sut.DeleteAsync(expected1.Id + 1));
            actual.Should().BeEquivalentTo(expected1);
        }

        [AutoData]
        [Theory]
        public async Task UpdateAsync_GivenOriginalEntityAndUpdatedShouldBeTheSame(Patient entity,Patient actual)
        {
            //Arrange
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

            entity.EmailAddress = actual.EmailAddress;
            entity.FullName = actual.FullName;
            entity.Gender = actual.Gender;
            entity.InsuranceNumber = actual.InsuranceNumber;
            var sut = new GenericRepository<Patient>(_dbContext);

            //Act
            var expected = await sut.UpdateAsync(entity);

            //Assert
            expected.Should().BeEquivalentTo(actual, options =>
                options.Excluding(x => x.Id));
        }
        [AutoData]
        [Theory]
        public async Task UpdateAsync_GivenNonExistingEntityShouldThrowErrow(Patient entity)
        {
            //Arrange
            var sut = new GenericRepository<Patient>(_dbContext);
            //Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => sut.UpdateAsync(entity));
        }
        [Fact]
        public async Task GetEntityWith_SholdReturnEntityWithNestedEntity()
        {
            //Arrange
            var department = new Department() { Description = "yo", Id = 1, Name = "Name" };
            var room = new Room() { Id = 1, Department = department, RoomNumber = 20 };

             _dbContext.Add(room);
            await _dbContext.SaveChangesAsync();
            var sut = new GenericRepository<Room>(_dbContext);
            var roomList = new List<Room>();
            roomList.Add(room);

            //Act
            var actual = sut.GetWithEntity(c => c.Department).ToList();
            //Assert
            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(roomList);
        }

    }
}