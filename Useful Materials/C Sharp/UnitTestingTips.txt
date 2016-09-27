Unit test Exam - Steps

1.Install:
	1.1. NUnit
	1.2. NUnit3TestAdapter
	1.3. NUnitTestAdapter
	1.4. Moq
	1.5. CastleCore
	1.6. Autofixture - сиздава обект вместо нас на базата на random
2. Reference in test to project
Naming Convection - method name, expected result, when passed parameters
3. Test Factory

	Test all valid cases
	Test if throws exeption
	Test if exeption message is correct
	
	[testCase] => парамезиран тест
	
[TestCase("Angel")]
        public void CreateCreature_ShouldReturnCorespondingCreatureInstance
		_WhenStringPassedRepresentsValidCreature (string name)
        {
            var factory = new CreaturesFactory();

            var creature = factory.CreateCreature(name);

            Assert.AreEqual(name, creature.GetType().Name);
        }
			
			creature.GetType().Name - Така взимаме името на класа
			
4. Test Engin - public methods via interface
ptotected methods - using Moq.Protected

Създаваме си папка Mocked Objects и там си създаваме класове с мокнати обекти, 
които наследяват оригиналните обекти

Никога не се моква обекта който се тества
mockedObject.Verify()=> проветяваме дали мокнатия обект реално се  е създал

Internal class=> make Visible:
1. Asembly info
2 add artibutr 
[assembly:InternalVisibleTo("AtherProjectInSolution.Tests")]
[assembly:InternalVisibleTo("Moq")]

Za da mojem da prezapiswame metodite - pravim gi virtualni

STATIC METHOD

public void ReturnNewCommand_WhenInputIsValid()
        {
            var inputToTest = "CreateCategory ForMale";

            var result = Command.Parse(inputToTest);
// Proveriavame dali neshto e instanciq na daden obect
            Assert.IsInstanceOf<Command>(result);
        }