namespace TestProject_Tierhandlung
{
    using Tierhandlung_WPF_Anwendung_mit_Entity_Framework.Services;
    using Tierhandlung_WPF_Anwendung_mit_Entity_Framework.DbModels;

    namespace Tests
    {
        [TestClass]
        public class TierheimTests
        {
            private Tierheim CreateTierheim()
            {
                var context = new TierheimContext();
                return new Tierheim(context);
            }

            [TestMethod]
            public void CreateNewAccount_ShouldReturnTrue_WhenUserDoesNotExist()
            {
                var tierheim = CreateTierheim();
                var result = tierheim.create_new_account("testuser2", "1234", false);

                Assert.IsTrue(result);
            }

            [TestMethod]
            public void CreateNewAccount_ShouldReturnFalse_WhenUserAlreadyExists()
            {
                var tierheim = CreateTierheim();
                tierheim.create_new_account("testuser2", "1234", false);

                var result = tierheim.create_new_account("testuser", "1234", false);

                Assert.IsFalse(result);
            }

            [TestMethod]
            public void AddAnimal_ShouldIncreaseAnimalCount()
            {
                var tierheim = CreateTierheim();

                tierheim.add_animal("Bello", "Hund", DateTime.Now, "Testbeschreibung");

                Assert.AreEqual(1, tierheim.alle_tiere.Count);
            }

            [TestMethod]
            public void CheckIfRequestExists_ShouldReturnTrue_WhenRequestWasCreated()
            {
                var tierheim = CreateTierheim();

                tierheim.create_new_account("user", "1234", false);
                tierheim.add_animal("Minka", "Katze", DateTime.Now, "Test");

                var user = tierheim.get_user("user", "1234");
                var tier = tierheim.alle_tiere[0];

                tierheim.anfrage_stellen(user.NutzerId, tier.TierId, "Test Anfrage");

                var exists = tierheim.check_if_request_exists(tier.TierId, user.NutzerId);

                Assert.IsTrue(exists);
            }

            [TestMethod]
            public void Filter_ShouldReturnOnlyMatchingAnimals()
            {
                var tierheim = CreateTierheim();

                tierheim.add_animal("Bello", "Hund", DateTime.Now, "Test");
                tierheim.add_animal("Minka", "Katze", DateTime.Now, "Test");

                tierheim.filter("Hund");

                Assert.AreEqual(1, tierheim.gefilterte_tiere.Count);
            }
        }
    }
}
