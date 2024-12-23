using NUnit.Framework;
using RestSharpBusinessLayer.PostUtils;


namespace RestSharpTestLayer.StepDefinitions
{
    [Binding]
    public class PostsStepDefinitions
    {
        public readonly ScenarioContext ScenarioContext;
        public PostsStepDefinitions(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;

        }

        [Given(@"I create a new post uisng id '([^']*)' title '([^']*)' and views '([^']*)'")]
        public void GivenICreateANewPostUisngIdTitleAndViews(string id, string title, int views)
        {
            var response = PostUtils.Post(id, title, views, System.Net.HttpStatusCode.Created);

            Assert.That(response.id, Is.EqualTo(id));
            Assert.That(response.title, Is.EqualTo(title));
            Assert.That(response.views, Is.EqualTo(views));
        }

        [When(@"I update a created post with id '([^']*)' title '([^']*)' and views '([^']*)'")]
        public void WhenIUpdateACreatedPostWithIdTitleAndViews(string id, string title, int views)
        {
            var response = PostUtils.Put(id, title, views, System.Net.HttpStatusCode.OK);
            ScenarioContext.Set(response, "Response");
        }


        [Then(@"I delete the created post with id '([^']*)'")]
        public void ThenIDeleteTheCreatedPostWithIdTitleAndViews(string id)
        {
            var result = PostUtils.DeletePost(id, System.Net.HttpStatusCode.OK);

            Assert.AreEqual(result, true);
        }


        [Then(@"I verify the updated post with id '([^']*)' title '([^']*)' and views '([^']*)'")]
        public void ThenIVerifyTheUpdatedPostWithIdTitleAndViews(string id, string title, int views)
        {
            var response = ScenarioContext.Get<TestData>("Response");
            Assert.That(response.id, Is.EqualTo(id));
            Assert.That(response.title, Is.EqualTo(title));
            Assert.That(response.views, Is.EqualTo(views));
        }

        [When(@"I read a created post with id '([^']*)' title '([^']*)' and views '([^']*)'")]
        public void WhenIReadACreatedPostWithIdTitleAndViews(string id, string title, int views)
        {
            var response = PostUtils.Get(id, System.Net.HttpStatusCode.OK);

            Assert.That(response.id, Is.EqualTo(id));
        }
    }
}
