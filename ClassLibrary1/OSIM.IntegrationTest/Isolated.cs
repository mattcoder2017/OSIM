using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;
using System.Transactions;

namespace OSIM.IntegrationTest
{
    public class Isolated : Attribute, ITestAction
    {
        private TransactionScope transcope;
        public ActionTargets Targets
        {
            get {   return ActionTargets.Test;}}

        public void AfterTest(ITest test)
        {transcope.Dispose();}

        public void BeforeTest(ITest test)
        {transcope = new TransactionScope();}
    }
}
