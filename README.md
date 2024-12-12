### PE1 Assignment - Blazor Server Application for Visualizing Open Data

#### Task Description:

Develop a Blazor Server application to visualize all public drinkwater places in Gent. Your data set can be found here:

[Open Data Gent](https://data.stad.gent/)

#### Requirements:

1. **Homepage**: Create an overview page displaying a list of items from your chosen dataset (e.g., in a table), showing only key properties.

2. **Details Page**: Clicking on an item from the homepage should redirect to a page with detailed information about the selected item.

3. **Form to Add New Items**: Implement a form to add new items to the dataset (in-memory only). Upon starting the application, read and convert the dataset to C# objects and store them in a collection in memory.

4. **Form to Edit Items**: Implement a form to edit existing items (in-memory). The form should contain fields relevant to your chosen dataset.

5. **Delete Items**: Implement functionality to delete items (in-memory).

6. **Data Persistence**: Since the data is held in memory, changes will be lost when the application is restarted.

7. **Newsletter Subscription**: On **every page**, provide a form for users to subscribe to a fictional newsletter by entering an email address. After clicking the subscribe button, hide the form and show a confirmation message. There is no need to store the email address.

#### Guidelines:

- Use Blazor components as much as possible.
- Design a visually appealing application layout, and feel free to use Bootstrap components.
- You must download the data (in CSV, JSON, or XML format) and place it in the **Data** folder of your **Core** project. The application should not retrieve data from external APIs.

#### Development Steps:

1. Use tools like [JSON2CSharp](https://json2csharp.com/), [CsvHelper](https://joshclose.github.io/CsvHelper/), or [System.Text.Json](https://learn.microsoft.com/en-us/dotnet/api/system.text.json?view=net-6.0) to convert your dataset into C# objects.
2. Ensure the dataset file is included in your **Core** project and marked as **Content** so it can be accessed during evaluation.
3. Familiarize yourself with how to read these files in your code.

---

This task is aimed at developing a fully functional Blazor Server application that visualizes and interacts with open data while adhering to best practices for code structure and component-based design.
