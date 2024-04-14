using System;
using System.Windows.Forms;
using GeneradorDatosPrueba;
using ExportadorDatos;

public class MyForm : Form
{
    static List<string>? datos;
    private Label label1, label2, label3, label4;
    private TextBox textBox;
    private ComboBox comboBox1, comboBox2, comboBox3;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1416:Validate platform compatibility", Justification = "This application is intended to be run on Windows.")]
    public MyForm()
    {
        datos = new List<string>();
        Text = "Mi Ventana";
        Width = 900;
        Height = 400;
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        //Apartado Visual
        //Parte Izquierda
        label1 = new Label() { Text = "Numero de registros", Top = 10, Left = 10, Width = 150 };
        textBox = new TextBox() { Top = label1.Bottom + 10, Left = 10, Width = 150, MaxLength = 5};

        label2 = new Label() { Text = "Apellido 1", Top = textBox.Bottom + 10, Left = 10, Width = 150 };
        comboBox1 = new ComboBox() { Top = label2.Bottom + 10, Left = 10, DropDownStyle = ComboBoxStyle.DropDownList, Width = 150 };
        comboBox1.Items.AddRange(new string[] { "Selecciona el lenguaje", "Ruso", "Español", "Chino", "Frances" });
        comboBox1.SelectedIndex = 0;

        label3 = new Label() { Text = "Apellido 2", Top = comboBox1.Bottom + 10, Left = 10, Width = 150 };
        comboBox2 = new ComboBox() { Top = label3.Bottom + 10, Left = 10, DropDownStyle = ComboBoxStyle.DropDownList, Width = 150 };
        comboBox2.Items.AddRange(new string[] { "Selecciona el lenguaje", "Ruso", "Español", "Chino", "Frances" });
        comboBox2.SelectedIndex = 0;

        label4 = new Label() { Text = "Nombre", Top = comboBox2.Bottom + 10, Left = 10, Width = 150 };
        comboBox3 = new ComboBox() { Top = label4.Bottom + 10, Left = 10, DropDownStyle = ComboBoxStyle.DropDownList, Width = 150 };
        comboBox3.Items.AddRange(new string[] { "Selecciona el lenguaje", "Ruso", "Español", "Chino", "Frances" });
        comboBox3.SelectedIndex = 0;
        Button button = new Button() { Text = "Generar Dummy Data", Top = comboBox3.Top, Left = comboBox3.Right + 10, Width = 150 };

        ComboBox comboBox4 = new ComboBox() { Top = comboBox3.Bottom + 10, Left = 10, DropDownStyle = ComboBoxStyle.DropDownList, Width = 150 };
        comboBox4.Items.AddRange(new string[] { "Selecciona el formato", "CSV", "JSON", "SQL", "XML" });
        comboBox4.SelectedIndex = 0;
        Button button2 = new Button() { Text = "Generar Formato", Top = comboBox4.Top, Left = comboBox4.Right + 10, Width = 150 };

        Controls.Add(label1);
        Controls.Add(textBox);
        Controls.Add(label2);
        Controls.Add(comboBox1);
        Controls.Add(label3);
        Controls.Add(comboBox2);
        Controls.Add(label4);
        Controls.Add(comboBox3);
        Controls.Add(button);
        Controls.Add(comboBox4);
        Controls.Add(button2);

        //Parte Derecha
        DataGridView dataGridView = new DataGridView()
        {
            ColumnCount = 1,
            ColumnHeadersVisible = true,
            Top = label1.Top,
            Left = button.Right + 10,
            Width = 500,
            Height = 300
        };

        dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridView.Columns[0].Name = "Alumnos";

        Controls.Add(dataGridView);

        //Eventos
        //Validación de TextBox
        textBox.TextChanged += (sender, e) =>
        {
            if (int.TryParse(textBox.Text, out int numValue))
            {
                if (numValue > 50000)
                {
                    MessageBox.Show("El número introducido no puede ser mayor que 50000");
                    textBox.Text = "50000";
                }
            }
            else
            {
                MessageBox.Show("Por favor, introduce un número válido");
                textBox.Text = "";
            }
        };
        //Boton Generar Dummy Data
        button.Click += (sender, e) =>
        {
            dataGridView.Rows.Clear();

            // Asegúrate de que los valores estén disponibles y sean válidos
            if (int.TryParse(textBox.Text, out int noRegistros) &&
                comboBox1.SelectedIndex > 0 &&
                comboBox2.SelectedIndex > 0 &&
                comboBox3.SelectedIndex > 0)
            {
                // Los índices de ComboBox comienzan en 0, por lo que restamos 1 para obtener los valores correctos
                int ap1 = comboBox1.SelectedIndex;
                int ap2 = comboBox2.SelectedIndex;
                int name = comboBox3.SelectedIndex;

                // Llama a la función Generar()
                datos = Generador.Generar(noRegistros, ap1, ap2, name);

                // Escribe los datos en la tabla
                foreach (string dato in datos)
                {
                    dataGridView.Rows.Add(dato);
                }
            }
            else
            {
                // Muestra un mensaje de error si los valores no están disponibles o no son válidos
                MessageBox.Show("Por favor, ingresa un número válido y selecciona una opción en cada ComboBox.");
            }
        };

        //Boton Generar Formato
        button2.Click += (sender, e) =>
        {
            // Asegúrate de que los valores estén disponibles y sean válidos
            if (comboBox4.SelectedIndex < 0 || datos == null || datos.Count == 0)
            {
                // Muestra un mensaje de error si los valores no están disponibles o no son válidos
                MessageBox.Show("Por favor, selecciona un formato de exportación.");
            }
            else
            {
                Exportador.Eleccion(comboBox4.SelectedIndex, datos);
                MessageBox.Show("Descarga realizada con éxito. Revisa la carpeta del proyecto para ver el archivo generado.");
            }

        };
    }
    [STAThread]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1416:Validate platform compatibility", Justification = "This application is intended to be run on Windows.")]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MyForm());
    }
}