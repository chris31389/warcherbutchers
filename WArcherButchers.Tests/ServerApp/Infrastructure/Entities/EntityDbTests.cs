using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WArcherButchers.ServerApp.Infrastructure;

namespace WArcherButchers.Tests.ServerApp.Infrastructure.Entities
{
    [TestFixture]
    public class EntityDbTests : DbTests<TestDbContext>
    {
        [Test]
        public async Task GivenEntity_WhenISave_ThenCreatedAtUtcIsPopulated()
        {
            TestEntity testEntity = new TestEntity(1);
            using (DbContext dbContext = GetDbContext())
            {
                TestEntityRepository testEntityRepository = new TestEntityRepository(dbContext);
                await testEntityRepository.SaveAsync(testEntity);
            }

            Assert.That(testEntity.CreatedAtUtc, Is.Not.EqualTo(default(DateTime)));
            Assert.That(testEntity.CreatedAtUtc, Is.GreaterThanOrEqualTo(DateTime.UtcNow.AddMinutes(-1)));
            Assert.That(testEntity.CreatedAtUtc, Is.LessThanOrEqualTo(DateTime.UtcNow.AddMinutes(1)));
        }

        [Test]
        public async Task GivenEntity_WhenISaveThenGet_ThenCreatedAtUtcIsPopulated()
        {
            TestEntity testEntity = new TestEntity(1);
            using (DbContext dbContext = GetDbContext())
            {
                TestEntityRepository testEntityRepository = new TestEntityRepository(dbContext);
                await testEntityRepository.SaveAsync(testEntity);
            }

            using (DbContext dbContext = GetDbContext())
            {
                TestEntityRepository testEntityRepository = new TestEntityRepository(dbContext);
                TestEntity testEntityDb = await testEntityRepository.GetAsync(testEntity.Id);
                Assert.That(testEntityDb.CreatedAtUtc, Is.Not.EqualTo(default(DateTime)));
                Assert.That(testEntityDb.CreatedAtUtc, Is.EqualTo(testEntity.CreatedAtUtc));
                Assert.That(testEntityDb.CreatedAtUtc, Is.GreaterThanOrEqualTo(DateTime.UtcNow.AddMinutes(-1)));
                Assert.That(testEntityDb.CreatedAtUtc, Is.LessThanOrEqualTo(DateTime.UtcNow.AddMinutes(1)));
            }
        }

        [Test]
        public async Task GivenEntity_WhenISaveInTwoSessions_ThenCreatedAtUtcIsSameOnBoth()
        {
            TestEntity testEntity = new TestEntity(1);
            using (DbContext dbContext = GetDbContext())
            {
                TestEntityRepository testEntityRepository = new TestEntityRepository(dbContext);
                await testEntityRepository.SaveAsync(testEntity);
            }

            TestEntity testEntityDb1;
            using (DbContext dbContext = GetDbContext())
            {
                TestEntityRepository testEntityRepository = new TestEntityRepository(dbContext);
                testEntityDb1 = await testEntityRepository.GetAsync(testEntity.Id);
                testEntityDb1.UpdateValue(2);
                await testEntityRepository.SaveAsync(testEntityDb1);
            }

            using (DbContext dbContext = GetDbContext())
            {
                TestEntityRepository testEntityRepository = new TestEntityRepository(dbContext);
                TestEntity testEntityDb = await testEntityRepository.GetAsync(testEntity.Id);
                Assert.That(testEntityDb.CreatedAtUtc, Is.Not.EqualTo(default(DateTime)));
                Assert.That(testEntityDb.CreatedAtUtc, Is.EqualTo(testEntityDb1.CreatedAtUtc));
            }
        }

        [Test]
        public async Task GivenEntity_WhenISave_ThenModifiedAtUtcIsPopulated()
        {
            TestEntity testEntity = new TestEntity(1);
            using (DbContext dbContext = GetDbContext())
            {
                TestEntityRepository testEntityRepository = new TestEntityRepository(dbContext);
                await testEntityRepository.SaveAsync(testEntity);
            }

            Assert.That(testEntity.LastModifiedAtUtc, Is.Not.EqualTo(default(DateTime)));
            Assert.That(testEntity.LastModifiedAtUtc, Is.GreaterThanOrEqualTo(DateTime.UtcNow.AddMinutes(-1)));
            Assert.That(testEntity.LastModifiedAtUtc, Is.LessThanOrEqualTo(DateTime.UtcNow.AddMinutes(1)));
        }

        [Test]
        public async Task GivenEntity_WhenISaveThenGet_ThenModifiedAtUtcIsPopulated()
        {
            TestEntity testEntity = new TestEntity(1);
            using (DbContext dbContext = GetDbContext())
            {
                TestEntityRepository testEntityRepository = new TestEntityRepository(dbContext);
                await testEntityRepository.SaveAsync(testEntity);
            }

            using (DbContext dbContext = GetDbContext())
            {
                TestEntityRepository testEntityRepository = new TestEntityRepository(dbContext);
                TestEntity testEntityDb = await testEntityRepository.GetAsync(testEntity.Id);
                Assert.That(testEntityDb.LastModifiedAtUtc, Is.Not.EqualTo(default(DateTime)));
                Assert.That(testEntityDb.LastModifiedAtUtc, Is.EqualTo(testEntity.LastModifiedAtUtc));
                Assert.That(testEntityDb.LastModifiedAtUtc, Is.GreaterThanOrEqualTo(DateTime.UtcNow.AddMinutes(-1)));
                Assert.That(testEntityDb.LastModifiedAtUtc, Is.LessThanOrEqualTo(DateTime.UtcNow.AddMinutes(1)));
            }
        }

        [Test]
        public async Task GivenEntity_WhenISaveInTwoSessions_ThenModifiedAtUtcIsPopulatedTwiceAndIsDifferent()
        {
            TestEntity testEntity = new TestEntity(1);
            Console.WriteLine($"CreatedAt: {SystemClock.UtcNow:O}");
            Console.WriteLine($"DomainCreatedAt: {testEntity.LastModifiedAtUtc:O}");

            await Task.Delay(2000);

            using (DbContext dbContext = GetDbContext())
            {
                TestEntityRepository testEntityRepository = new TestEntityRepository(dbContext);
                await testEntityRepository.SaveAsync(testEntity);
            }


            await Task.Delay(2000);

            TestEntity testEntityDb1;
            using (DbContext dbContext = GetDbContext())
            {
                TestEntityRepository testEntityRepository = new TestEntityRepository(dbContext);
                testEntityDb1 = await testEntityRepository.GetAsync(testEntity.Id);
                Console.WriteLine($"PersistenceLoadedCreatedAt: {testEntityDb1.LastModifiedAtUtc:O}");
                testEntityDb1.UpdateValue(2);
                await testEntityRepository.SaveAsync(testEntityDb1);
            }

            Console.WriteLine($"DomainUpdatedCreatedAt: {testEntityDb1.LastModifiedAtUtc:O}");

            await Task.Delay(2000);

            using (DbContext dbContext = GetDbContext())
            {
                TestEntityRepository testEntityRepository = new TestEntityRepository(dbContext);
                TestEntity testEntityDb = await testEntityRepository.GetAsync(testEntity.Id);
                Console.WriteLine($"PersistenceLoadedCreatedAt: {testEntityDb.LastModifiedAtUtc:O}");
                Assert.That(testEntityDb.LastModifiedAtUtc, Is.Not.EqualTo(default(DateTime)));
                Assert.That(testEntityDb.LastModifiedAtUtc, Is.EqualTo(testEntityDb1.LastModifiedAtUtc));
                Assert.That(testEntity.LastModifiedAtUtc, Is.Not.EqualTo(testEntityDb1.LastModifiedAtUtc));
            }
        }

        protected override TestDbContext CreateDbContext(DbContextOptions<TestDbContext> dbContextOptions)
            => new TestDbContext(dbContextOptions, new TestEntityTypeConfigurationFactory());
    }
}