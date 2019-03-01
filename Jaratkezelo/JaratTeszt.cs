using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaratkezelo
{
    [TestFixture]
    class JaratTeszt
    {
        Class1 j;

        [SetUp]
        public void Setup()
        {
            j = new Class1();
        }

        [Test]
        public void Jaratszamcsekk()
        {
            j.Ujjarat("0001", "A", "B", DateTime.Now);
            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.Ujjarat("0001", "A", "B", DateTime.Now);
                }
            );
        }

        [Test]
        public void JaratPeldanyositasnalArgumentekCsekk()
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.Ujjarat("", "A", "B", DateTime.Now);
                }
            );
            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.Ujjarat("0001", "", "B", DateTime.Now);
                }
            );
            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.Ujjarat("0001", "A", "", DateTime.Now);
                }
            );
        }

        [Test]
        public void JaratPeldanyositasnalKesesCsekk()
        {
            j.Ujjarat("0001", "A", "B", DateTime.Now);
            Assert.AreEqual(j.jaratok_lista[0].Keses , 0);
        }

        [Test]
        public void JaratKesesRosszParameterCsekk()
        {
            j.Ujjarat("0001", "A", "B", DateTime.Now);
            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.Keses("0001", 0);
                }
            );
            
        }

        [Test]
        public void JaratKesesNegativCsekk()
        {
            j.Ujjarat("0001", "A", "B", DateTime.Now);
            Assert.Throws<NegativKesesException>(
                () =>
                {
                    j.Keses("0001", -1);
                }
            );
        }

        [Test]
        public void JaratKesesNemLetezoJaratCsekk()
        {
            j.Ujjarat("0001", "A", "B", DateTime.Now);
            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.Keses("", 5);
                }
            );
        }

        [Test]
        public void MikorindulNemLetezoJaratCsekk()
        {
            j.Ujjarat("0001", "A", "B", DateTime.Now);
            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.MikorIndul("");
                }
            );
        }

        [Test]
        public void ValidIdotAdVisszaCsekk()
        {
            DateTime most = DateTime.Now;
            j.Ujjarat("0001", "A", "B", most);
            Assert.AreEqual(most, j.MikorIndul("0001"));
        }

        [Test]
        public void ValidIdotAdVisszaKesesselCsekk()
        {
            DateTime most = DateTime.Now;
            j.Ujjarat("0001", "A", "B", most);
            j.Keses("0001", 5);
            Assert.AreEqual(most.AddMinutes(5), j.MikorIndul("0001"));
        }

        [Test]
        public void JaratokRepuloterrolRosszInputCsekk()
        {
            j.Ujjarat("0001", "A", "B", DateTime.Now);
            Assert.Throws<ArgumentException>(
                () =>
                {
                    var valami = j.JaratokRepuloterrol("C");
                }
            );
        }

        [Test]
        public void JaratokRepuloterrolPontosReturnCsekk()
        {
            j.Ujjarat("0001", "A", "B", DateTime.Now);
            j.Ujjarat("0002", "A", "B", DateTime.Now);
            j.Ujjarat("0003", "A", "C", DateTime.Now);
            j.Ujjarat("0004", "B", "A", DateTime.Now);

            Assert.AreEqual(j.JaratokRepuloterrol("A").Count, 3);
        }

    }
}
