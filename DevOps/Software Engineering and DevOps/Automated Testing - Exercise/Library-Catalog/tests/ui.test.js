const {test, expect} =require("@playwright/test");


//Login Page
//Verify That the "Login" Button Is Visible
test("Verify 'Login' button is visible", async({page}) => {
    await page.goto("http://localhost:3000/");
    await page.waitForSelector("nav.navbar");
    const loginLink = await page.$("a[href='/login']");
    const isVisible = await loginLink.isVisible();

    expect(isVisible).toBe(true);
}); 

//Submit the Form with Valid Credentials
test("Login with valid credentials", async({page}) => {
    await page.goto("http://localhost:3000/login");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await page.click("input[type='submit']");
    await page.$("a[href='/catalog']");

    expect(page.url()).toBe("http://localhost:3000/catalog");
}); 

//Submit the Form with Empty Input Fields
test("Login with Empty Input Fields", async({page}) => {
    await page.goto("http://localhost:3000/login");
    await page.click("input[type='submit']");
    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$("a[href='/login']");

    expect(page.url()).toBe("http://localhost:3000/login");
}); 

//Submit the Form with Empty Email Input Field
test("Login with Empty Email Input Field", async({page}) => {
    await page.goto("http://localhost:3000/login");
    await page.fill("input[name='password']", "123456");
    await page.click("input[type='submit']");
    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$("a[href='/login']");

    expect(page.url()).toBe("http://localhost:3000/login");
}); 

//Submit the Form with Empty Password Input Field
test("Login with Empty Password Input Field", async({page}) => {
    await page.goto("http://localhost:3000/login");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.click("input[type='submit']");
    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$("a[href='/login']");

    expect(page.url()).toBe("http://localhost:3000/login");
}); 

//"Logout" Functionality
//Verify That the "Logout" Button Is Visible
test("Logout button is visible", async({page}) => {
    await page.goto("http://localhost:3000/login");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await page.click("input[type='submit']");
    const logoutLink = await page.$("a[href='javascript:void(0)']");
    await logoutLink.click();

    const redirectedURL = page.url();
    expect(redirectedURL).toBe("http://localhost:3000/catalog");
}); 


//Register Page
//Verify That the "Register" Button Is Visible
test("Verify 'Register' button is visible", async({page}) => {
    await page.goto("http://localhost:3000/");
    await page.waitForSelector("nav.navbar");
    const registerLink = await page.$("a[href='/register']");
    const isVisible = await registerLink.isVisible();

    expect(isVisible).toBe(true);
}); 

//Submit the Form with Valid Values
test("Register with valid credentials", async({page}) => {
    await page.goto("http://localhost:3000/register");
    await page.fill("input[name='email']", "polina@abv.bg");
    await page.fill("input[name='password']", "123456");
    await page.fill("input[name='confirm-pass']", "123456");
    await page.click("input[type='submit']");
    await page.$("a[href='/catalog']");

    expect(page.url()).toBe("http://localhost:3000/catalog");
}); 

//Submit the Form with Empty Values
test("Register with Empty Input Fields", async({page}) => {
    await page.goto("http://localhost:3000/register");
    await page.click("input[type='submit']");
    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$("a[href='/register']");

    expect(page.url()).toBe("http://localhost:3000/register");
}); 

//Submit the Form with Empty Email
test("Register with Empty Email", async({page}) => {
    await page.goto("http://localhost:3000/register");
    await page.fill("input[name='password']", "123456");
    await page.fill("input[name='confirm-pass']", "123456");
    await page.click("input[type='submit']");
    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$("a[href='/register']");

    expect(page.url()).toBe("http://localhost:3000/register");
}); 

//Submit the Form with Empty Password
test("Register with Empty Password", async({page}) => {
    await page.goto("http://localhost:3000/register");
    await page.fill("input[name='email']", "polina@abv.bg");
    await page.fill("input[name='confirm-pass']", "123456");
    await page.click("input[type='submit']");
    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$("a[href='/register']");

    expect(page.url()).toBe("http://localhost:3000/register");
}); 

//Submit the Form with Empty Confirm Password
test("Register with Empty Confirm Password", async({page}) => {
    await page.goto("http://localhost:3000/register");
    await page.fill("input[name='email']", "polina@abv.bg");
    await page.fill("input[name='password']", "123456");
    await page.click("input[type='submit']");
    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$("a[href='/register']");

    expect(page.url()).toBe("http://localhost:3000/register");
}); 

//Submit the Form with Different Passwords
test("Register with Different Passwords", async({page}) => {
    await page.goto("http://localhost:3000/register");
    await page.fill("input[name='email']", "polina@abv.bg");
    await page.fill("input[name='password']", "123456");
    await page.fill("input[name='confirm-pass']", "1234567");
    await page.click("input[type='submit']");
    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('Passwords don\'t match!');
        await dialog.accept();
    });

    await page.$("a[href='/register']");

    expect(page.url()).toBe("http://localhost:3000/register");
}); 


//AllBooks
//Verify That the "All Books" Link Is Visible
test("Verify 'All Books' link is visible", async({page}) => {
    await page.goto("http://localhost:3000/");
    await page.waitForSelector("nav.navbar");
    const allBooksLink = await page.$("a[href='/catalog']");
    const isVisible = await allBooksLink.isVisible();

    expect(isVisible).toBe(true);
});

//Verify That the "All Books" Link Is Visible after user login
test("Verify 'All Books' link is visible after user login", async({page}) => {
    await page.goto("http://localhost:3000/");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await page.click("input[type='submit']");
    const allBooksLink = await page.$("a[href='/catalog']");
    const isVisible = await allBooksLink.isVisible();

    expect(isVisible).toBe(true);
}); 

//Verify That All Books Are Displayed
test("Login and verify all books are displayed", async({page}) => {
    await page.goto("http://localhost:3000/login");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await Promise.all([
        page.click("input[type='submit']"),
        page.waitForURL("http://localhost:3000/catalog")
    ]);
    
    await page.waitForSelector(".dashboard");
    const bookElements = await page.$$(".other-books-list li");

    expect(bookElements.length).toBeGreaterThan(0);
}); 

//Verify That No Books Are Displayed
test("Login and verify that no books are displayed", async({page}) => {
    await page.goto("http://localhost:3000/login");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await Promise.all([
        page.click("input[type='submit']"),
        page.waitForURL("http://localhost:3000/catalog")
    ]);
    
    await page.waitForSelector(".dashboard");
    const noBooks = await page.textContent(".no-books");

    expect(noBooks).toBe("No books in database!");
}); 


//"Details" Page
//Verify That Logged-In User Sees Details Button and Button Works Correctly
test("Login and navigate to details page", async({page}) => {
    await page.goto("http://localhost:3000/login");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await Promise.all([
        page.click("input[type='submit']"),
        page.waitForURL("http://localhost:3000/catalog")
    ]);
    await page.click("a[href='/catalog']");
    await page.waitForSelector(".otherBooks");
    await page.click(".otherBooks a.button");
    await page.waitForSelector(".book-information");
    const detailsTitle = await page.textContent(".book-information h3");

    expect(detailsTitle).toBe("Test Book");
}); 

//Verify That the "My Books" Link Is Visible
test("Verify 'My Books' link is visible after user login", async({page}) => {
    await page.goto("http://localhost:3000/");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await page.click("input[type='submit']");
    const myBookLink = await page.$("a[href='/profile']");
    const isVisible = await myBookLink.isVisible();

    expect(isVisible).toBe(true);
}); 


//Add Book
//Verify That the "Add Book" Link Is Visible
test("Verify 'Add Book' link is visible after user login", async({page}) => {
    await page.goto("http://localhost:3000/");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await page.click("input[type='submit']");
    const addBookLink = await page.$("a[href='/create']");
    const isVisible = await addBookLink.isVisible();

    expect(isVisible).toBe(true);
}); 

//Submit the Form with Correct Data
test("Add Book with correct data", async({page}) => {
    await page.goto("http://localhost:3000/login");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await Promise.all([
        page.click("input[type='submit']"),
        page.waitForURL("http://localhost:3000/catalog")
    ]);
    await page.click("a[href='/create']");
    await page.waitForSelector("#create-form");
    await page.fill("#title", "Test Book");
    await page.fill("#description", "This is test book description");
    await page.fill("#image", "http://example.com/book-image.jpg");
    await page.selectOption("#type", "Fiction");
    await page.click("#create-form input[type='submit']");

    await page.waitForURL("http://localhost:3000/catalog");

    expect(page.url()).toBe("http://localhost:3000/catalog");
}); 

//Submit the Form with Empty Title Field
test("Add Book with empty title field", async({page}) => {
    await page.goto("http://localhost:3000/login");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await Promise.all([
        page.click("input[type='submit']"),
        page.waitForURL("http://localhost:3000/catalog")
    ]);
    await page.click("a[href='/create']");
    await page.waitForSelector("#create-form");
    await page.fill("#description", "This is test book description");
    await page.fill("#image", "http://example.com/book-image.jpg");
    await page.selectOption("#type", "Fiction");
    await page.click("#create-form input[type='submit']");
    page.on("dialog", async dialog => {
        expect(dialog.type()).toContain("alert");
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    })

    await page.$("a[href='/create']");

    expect(page.url()).toBe("http://localhost:3000/create");
}); 

//Submit the Form with Empty Description Field
test("Add Book with Empty Description Field", async({page}) => {
    await page.goto("http://localhost:3000/login");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await Promise.all([
        page.click("input[type='submit']"),
        page.waitForURL("http://localhost:3000/catalog")
    ]);
    await page.click("a[href='/create']");
    await page.waitForSelector("#create-form");
    await page.fill("#title", "Test Book");
    await page.fill("#image", "http://example.com/book-image.jpg");
    await page.selectOption("#type", "Fiction");
    await page.click("#create-form input[type='submit']");
    page.on("dialog", async dialog => {
        expect(dialog.type()).toContain("alert");
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    })

    await page.$("a[href='/create']");

    expect(page.url()).toBe("http://localhost:3000/create");
}); 

//Submit the Form with Empty Image URL Field
test("Add Book with Empty Image URL Field", async({page}) => {
    await page.goto("http://localhost:3000/login");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await Promise.all([
        page.click("input[type='submit']"),
        page.waitForURL("http://localhost:3000/catalog")
    ]);
    await page.click("a[href='/create']");
    await page.waitForSelector("#create-form");
    await page.fill("#title", "Test Book");
    await page.fill("#descrition", "This is test description");
    await page.selectOption("#type", "Fiction");
    await page.click("#create-form input[type='submit']");
    page.on("dialog", async dialog => {
        expect(dialog.type()).toContain("alert");
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    })

    await page.$("a[href='/create']");

    expect(page.url()).toBe("http://localhost:3000/create");
}); 

//Verify That the User's Email Address Is Visible
test("Verify User's Email Address link is visible after user login", async({page}) => {
    await page.goto("http://localhost:3000/");
    await page.fill("input[name='email']", "peter@abv.bg");
    await page.fill("input[name='password']", "123456");
    await page.click("input[type='submit']");
    const userEmail = await page.$("div[id='user']");
    const isVisible = await userEmail.isVisible();

    expect(isVisible).toBe(true);
}); 