﻿using ArtifactAPI.Encoding;
using ArtifactAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtifactAPI.Tests
{
    [TestClass]
    public class EncodingTests
    {
        [TestMethod]
        public void EncodeString()
        {
            byte[] bytes = new byte[] { 0x4A, 0x57, 0x6B, 0x54, 0x5A, 0x58, 0x30, 0x35, 0x75, 0x77, 0x47, 0x44, 0x43, 0x52, 0x56, 0x34, 0x58, 0x51, 0x47, 0x79, 0x33, 0x51, 0x47, 0x4C, 0x6D, 0x71, 0x55, 0x42, 0x67, 0x34, 0x47, 0x51, 0x4A, 0x67, 0x47, 0x4C, 0x47, 0x67, 0x4F, 0x37, 0x41, 0x61, 0x41, 0x42, 0x52, 0x33, 0x4A, 0x6C, 0x5A, 0x57, 0x34, 0x76, 0x51, 0x6D, 0x78, 0x68, 0x59, 0x32, 0x73, 0x67, 0x52, 0x58, 0x68, 0x68, 0x62, 0x58, 0x42, 0x73, 0x5A, 0x51, 0x5F, 0x5F };
            string output = DeckEncoder.EncodeBytesToString(bytes);
            Assert.AreEqual(output, "ADCJWkTZX05uwGDCRV4XQGy3QGLmqUBg4GQJgGLGgO7AaABR3JlZW4vQmxhY2sgRXhhbXBsZQ__");
        }

        [TestMethod]
        public void DecodeDeck()
        {
            ArtifactClient client = new ArtifactClient();
            DecodedDeck deck = client.DecodeDeck("ADCJQUQI30zuwEYg2ABeF1Bu94BmWIBTEkLtAKlAZakAYmHh0JsdWUvUmVkIEV4YW1wbGU_");

            Assert.IsNotNull(deck);
            Assert.IsNotNull(deck.Heroes);
            Assert.IsNotNull(deck.Cards);
            Assert.IsFalse(string.IsNullOrEmpty(deck.Name));
        }

        [TestMethod]
        public void EncodeDeck()
        {
            ArtifactClient client = new ArtifactClient();

            string startDeckCode = "ADCJWkTZX05uwGDCRV4XQGy3QGLmqUBg4GQJgGLGgO7AaABR3JlZW4vQmxhY2sgRXhhbXBsZQ__";
            DecodedDeck deck = client.DecodeDeck(startDeckCode);
            string encodedDeckCode = client.EncodeDeck(deck);

            Assert.AreEqual(startDeckCode, encodedDeckCode);
        }

    }
}
