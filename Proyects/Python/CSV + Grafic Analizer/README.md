# CSV Analyzer + Charts — Python Project

**Programmer:** Andy Alejandro Rodriguez Rodriguez

Small data analysis and visualization project developed with **Python**, **NumPy**, and **Matplotlib**.

The program reads sales data from a CSV file, validates the required columns, performs basic numerical analysis, and generates charts to visualize the results.


# Features

* Read CSV files using **NumPy**.
* Validate required CSV columns.
* Display loaded data.
* Calculate basic sales statistics.
* Identify the most and least sold products.
* Calculate total units sold and total sales.
* Generate charts using **Matplotlib**.

# Project Structure

The project is organized into functions with different responsibilities:

* **`read_csv()`** — Reads the CSV file using NumPy.
* **`validate_columns()`** — Checks that the required columns exist.
* **`data_upload()`** — Loads and validates the data.
* **`show_data()`** — Displays the loaded data.
* **`analysis()`** — Performs numerical analysis.
* **`plot_chart()`** — Generates the charts.

# Dataset

The CSV contains sales information with the following columns:

```text
date
product
category
units_sold
unit_price
```

Example:

```text
2024-01-01,Wireless Mouse,Accessories,12,15.99
```

# Technologies

* **Python**
* **NumPy**
* **Matplotlib**

# Project Goal

This project was created to practice **CSV data processing, NumPy, basic data analysis, and data visualization with Matplotlib**.



