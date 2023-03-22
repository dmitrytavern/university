#include <QtWidgets>

class MainWindow : public QWidget
{
public:
  MainWindow(QWidget *parent = nullptr) : QWidget(parent)
  {
    m_label = new QLabel("Enter your name:", this);
    m_lineEdit = new QLineEdit(this);
    m_button = new QPushButton("Submit", this);

    m_label->setGeometry(10, 10, 150, 25);
    m_lineEdit->setGeometry(10, 35, 150, 25);
    m_button->setGeometry(10, 70, 150, 25);

    connect(m_button, &QPushButton::clicked, this, &MainWindow::onButtonClicked);
  }

private slots:
  void onButtonClicked()
  {
    QString name = m_lineEdit->text();

    QString message = "Hello, " + name + "!";
    QLabel *greetingLabel = new QLabel(message, this);
    greetingLabel->setGeometry(10, 110, 150, 25);
    greetingLabel->show();
  }

private:
  QLabel *m_label;
  QLineEdit *m_lineEdit;
  QPushButton *m_button;
};

int main(int argc, char *argv[])
{
  QApplication app(argc, argv);
  MainWindow mainWindow;
  mainWindow.setGeometry(100, 100, 170, 150);
  mainWindow.setWindowTitle("Lab 1 - Input/Output");
  mainWindow.show();
  return app.exec();
}