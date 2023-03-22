#include <QtWidgets>

bool isPrime(int number, int index)
{
  int _index = index + 1;
  if (_index < number && (number % _index) != 0)
    return isPrime(number, _index);
  return _index == number;
}

class MainWindow : public QWidget
{
public:
  MainWindow(QWidget *parent = nullptr) : QWidget(parent)
  {
    QVBoxLayout *layout = new QVBoxLayout(this);
    QFont labelFont("Arial", 16);

    layoutLabel = new QLabel("Enter number:");
    layoutLabel->setFont(labelFont);
    layout->addWidget(layoutLabel);

    layoutInput = new QLineEdit();
    layoutInput->setValidator(new QIntValidator());
    layout->addWidget(layoutInput);

    layoutButton = new QPushButton("Submit");
    layoutButton->setEnabled(false);
    layout->addWidget(layoutButton);

    layoutResult = new QLabel("Result: ");
    layout->addWidget(layoutResult);

    layout->setAlignment(Qt::AlignTop);

    connect(layoutButton, &QPushButton::clicked, this, &MainWindow::onButtonClicked);
    connect(layoutInput, &QLineEdit::textChanged, this, &MainWindow::onInputEditLineHandler);
  }

private slots:
  void onButtonClicked()
  {
    int number = layoutInput->text().toInt();

    if (isPrime(number, 1))
    {
      layoutResult->setText("Result: is prime number");
    }
    else
    {
      layoutResult->setText("Result: is not prime number");
    }
  }

  void onInputEditLineHandler(const QString &text)
  {
    layoutButton->setEnabled(!text.isEmpty() && text.toInt() >= 0);
  }

private:
  QLabel *layoutLabel;
  QLabel *layoutResult;
  QLineEdit *layoutInput;
  QPushButton *layoutButton;
};

int main(int argc, char *argv[])
{
  QApplication app(argc, argv);
  MainWindow mainWindow;
  mainWindow.setFixedSize(400, 150);
  mainWindow.setWindowTitle("Lab 1 - Finding prime number");
  mainWindow.show();
  return app.exec();
}