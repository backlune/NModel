using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using NModel;
using NModel.Attributes;
using NModel.Execution;
using NUnit.Framework;

namespace NModel.Tests
{
   [TestFixture]
   public class ModelUsingSetTest
   {

      [Test]
      public void CreateModelProgramFromModelWithDomainSetWithMoreThanThreeItems()
      {
         //Act
         var mp = new LibraryModelProgram(this.GetType().Assembly, "TestSetModel");

         //Assert
         Assert.IsNotNull(mp);
      }
   }


   }


namespace TestSetModel
{

   public static class TestModel
   {
      private static int value;

      [Action]
      private static void Start([Domain("TestSet")] int val)
      {
         value = val;
      }

      [Action]
      private static void Dec()
      {
         value--;
      }

      private static bool DecEnabled()
      {
         return value > 0;
      }

      private static Set<int> TestSet()
      {
         return new Set<int>(3, 13, 23, 24);
      }
   }
}
