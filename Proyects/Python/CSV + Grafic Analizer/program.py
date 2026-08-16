import numpy as np
import matplotlib.pyplot as plt

# Functions
def read_csv(file_path):
    data = np.genfromtxt(
        file_path,
        delimiter=",",
        dtype=None,
        names=True,
        encoding="utf-8"
    )
    return data

def validate_columns(data):
    required_columns = [
        "date",
        "product",
        "category",
        "units_sold",
        "unit_price"
    ]

    if data.size == 0:
        return False, "CSV is empty"

    csv_columns = data.dtype.names

    for column in required_columns:
        if column not in csv_columns:
            return False, f"Missing required column: {column}"

    return True, "CSV columns are valid"

def data_upload(file_path):

    banner = False

    while banner == False:

        if file_path != "":
            try:
                data = read_csv(file_path)
                banner = True

            except FileNotFoundError:
                print("The file does not exist")

        else:
            print("The address cannot be empty")

    file_name = file_path.split("/")[-1]

    print(f"The data from file {file_name} was loaded")
    print(f"{data.size} rows loaded from {file_name}")

    is_valid, message = validate_columns(data)

    if not is_valid:
        print("The columns in the CSV file do not match those required")
        exit()

    print(message)

    return data

def show_data(data):
    for row in data:
        print(row)

def plot_chart(datos):

    productos = datos["product"]
    unidades = datos["units_sold"]

    plt.bar(productos, unidades)

    plt.xlabel("Product")
    plt.ylabel("Units sold")
    plt.title("Units sold by product")

    plt.xticks(rotation=45)
    plt.tight_layout()

    plt.show()

def analysis(data):

    # Total units sold
    total_units = np.sum(data["units_sold"])

    # Average unit price
    average_price = np.mean(data["unit_price"])

    # Most sold product
    max_units = np.max(data["units_sold"])
    max_index = np.argmax(data["units_sold"])
    most_sold_product = data["product"][max_index]

    # Least sold product
    min_units = np.min(data["units_sold"])
    min_index = np.argmin(data["units_sold"])
    least_sold_product = data["product"][min_index]

    # Total sales
    sales = data["units_sold"] * data["unit_price"]
    total_sales = np.sum(sales)

    print("\n--- Sales Analysis ---")

    print(f"Total units sold: {total_units}")
    print(f"Average unit price: ${average_price:.2f}")

    print(
        f"Most sold product: {most_sold_product} "
        f"({max_units} units)"
    )

    print(
        f"Least sold product: {least_sold_product} "
        f"({min_units} units)"
    )

    print(f"Total sales: ${total_sales:.2f}")

#body
datos = data_upload('CSV/sales_data.csv')

show_data(datos)

analysis(datos)

plot_chart(datos)