using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ReferenceUpdatedCheckerTests
    {
        [Test]
        public void TheFirstCheckReturnsTrue()
        {
            ReferenceUpdatedChecker<float, FloatReference> checker = new ReferenceUpdatedChecker<float, FloatReference>();

            FloatReference reference = new FloatReference(0);

            Assert.True(checker.hasBeenUpdated(reference));
        }

        [Test]
        public void AfterReferenceChangesCheckerReturnsTrue() {
            ReferenceUpdatedChecker<float, FloatReference> checker = new ReferenceUpdatedChecker<float, FloatReference>();

            FloatReference reference = new FloatReference(0);
            checker.hasBeenUpdated(reference);
            reference.increment(1);

            Assert.True(checker.hasBeenUpdated(reference));
        }

        [Test]
        public void IfReferenceHasntChangedCheckerReturnsFalse() {
            ReferenceUpdatedChecker<float, FloatReference> checker = new ReferenceUpdatedChecker<float, FloatReference>();

            FloatReference reference = new FloatReference(0);
            checker.hasBeenUpdated(reference);

            Assert.False(checker.hasBeenUpdated(reference));
        }
    }
}
