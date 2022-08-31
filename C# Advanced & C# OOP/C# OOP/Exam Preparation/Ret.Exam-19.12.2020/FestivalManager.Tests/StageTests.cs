// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void AddPerformerShouldThrowExceptionIfValueIsNull()
	    {
			Performer performer = null;
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() =>
		   {
			   stage.AddPerformer(performer);
		   }, "Can not be null!");
		}

		[Test]
		public void AddPerformerShouldThrowExceptionIfAgeIsUnder18()
		{
			Performer performer = new Performer("Polina", "Drumeva", 17);
			Stage stage = new Stage();

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddPerformer(performer);
			}, "You can only add performers that are at least 18.");
		}

		[Test]
		public void AddPerformerShouldAddedPerformerSuccsefully()
		{
			Performer performer = new Performer("Polina", "Drumeva", 20);
			Stage stage = new Stage();
			stage.AddPerformer(performer);

			
			int actualCount = stage.Performers.Count;
			int expectedCount = 1;

			Assert.AreEqual(actualCount, expectedCount);
				 
		}

		[Test]
		public void AddSongShouldThrowExceptionIfValueIsNull()
		{
			Song song = null;
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddSong(song);
			}, "Can not be null!");
		}

		[Test]
		public void AddSongShouldThrowExceptionIfDurationIsUnder1Min()
		{
			Song song = new Song("Maria", new TimeSpan(0, 0, 30) );
			Stage stage = new Stage();

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSong(song);
			}, "You can only add songs that are longer than 1 minute.");
		}

		
	}
}