const {test, expect} = require("@playwright/test");

//Test 1: Test If a User Can Add a Task
test ("user can add a task", async ({page}) => {
    await page.goto("http://localhost:5500/");
    await page.fill("#task-input", "Test Task");
    await page.click("#add-task");
    const taskText = await page.textContent(".task");

    expect(taskText).toContain("Test Task");
});


//Test 2: Test If a User Can Delete a Task
test ("user can delete a task", async ({page}) => {
    await page.goto("http://localhost:5500/");
    await page.fill("#task-input", "Test Task");
    await page.click(".task .delete-task");
    const tasks = await page.$$eval(".task", tasks => tasks.map(task => task.textContent));

    expect(tasks).not.toContain("Test Task");
});

//Test 3: Test If a User Can Mark a Task as Complete
test ("user can mark a task as complete", async ({page}) => {
    await page.goto("http://localhost:5500/");
    await page.fill("#task-input", "Test Task");
    await page.click("#add-task");
    await page.click(".task .task-complete");
    const completedTask = await page.$(".task.completed");

    expect(completedTask).not.toBeNull();
});

//Test 4: Test If a User Can Filter Tasks
test ("user can filter tasks", async ({page}) => {
    await page.goto("http://localhost:5500/");
    await page.fill("#task-input", "Test Task");
    await page.click("#add-task");
    await page.click(".task .task-complete");
    await page.selectOption("#filter", "Completed");
    const incompletedTask = await page.$(".task:not(.completed)");

    expect(incompletedTask).toBeNull();
});
