#include <QtWidgets>

class MainWindow : public QWidget
{
public:
  MainWindow(QWidget *parent = nullptr) : QWidget(parent)
  {
    QVBoxLayout *mainLayout = new QVBoxLayout(this);

    // Image layout
    image = new QLabel(this);
    image->setPixmap(QPixmap(":/resources/1.png"));
    image->setFixedSize(400, 400);

    QVBoxLayout *imageLayout = new QVBoxLayout();
    imageLayout->addWidget(image);

    imageButtonGroup = new QButtonGroup(this);
    imageButtonGroup->setExclusive(true);

    imageButton1 = new QRadioButton("Image 1");
    imageButton2 = new QRadioButton("Image 2");
    imageButton3 = new QRadioButton("Image 3");
    imageButtonGroup->addButton(imageButton1, 0);
    imageButtonGroup->addButton(imageButton2, 1);
    imageButtonGroup->addButton(imageButton3, 2);

    QHBoxLayout *imageButtonLayout = new QHBoxLayout();
    imageButtonLayout->addWidget(imageButton1);
    imageButtonLayout->addWidget(imageButton2);
    imageButtonLayout->addWidget(imageButton3);

    mainLayout->addLayout(imageLayout);
    mainLayout->addLayout(imageButtonLayout);

    // Color layout
    colorButtonGroup = new QButtonGroup(this);
    colorButtonGroup->setExclusive(true);

    colorButton1 = new QRadioButton("Add background");
    colorButton2 = new QRadioButton("Remove background");
    colorButtonGroup->addButton(colorButton1, 0);
    colorButtonGroup->addButton(colorButton2, 1);

    QHBoxLayout *colorButtonLayout = new QHBoxLayout();
    colorButtonLayout->addWidget(colorButton1);
    colorButtonLayout->addWidget(colorButton2);

    mainLayout->addLayout(colorButtonLayout);

    connect(imageButtonGroup, QOverload<QAbstractButton *>::of(&QButtonGroup::buttonClicked), this, &MainWindow::onImageGroupButtonClicked);

    connect(colorButtonGroup, QOverload<QAbstractButton *>::of(&QButtonGroup::buttonClicked), this, &MainWindow::onColorGroupButtonClicked);

    image->setStyleSheet("background-color: transparent");
  }

private slots:
  void onImageGroupButtonClicked(QAbstractButton *button)
  {
    if (button == imageButton1)
    {
      image->setPixmap(QPixmap(":/resources/1.png"));
    }

    if (button == imageButton2)
    {
      image->setPixmap(QPixmap(":/resources/2.png"));
    }

    if (button == imageButton3)
    {
      image->setPixmap(QPixmap(":/resources/3.png"));
    }
  }

  void onColorGroupButtonClicked(QAbstractButton *button)
  {
    if (button == colorButton1)
    {
      image->setStyleSheet("background-color: #DFF8E4");
    }

    if (button == colorButton2)
    {
      image->setStyleSheet("background-color: transparent");
    }
  }

private:
  QButtonGroup *imageButtonGroup;
  QRadioButton *imageButton1;
  QRadioButton *imageButton2;
  QRadioButton *imageButton3;

  QButtonGroup *colorButtonGroup;
  QRadioButton *colorButton1;
  QRadioButton *colorButton2;

  QLabel *image;
};

int main(int argc, char *argv[])
{
  QApplication app(argc, argv);
  MainWindow mainWindow;
  mainWindow.setGeometry(500, 500, 670, 650);
  mainWindow.setWindowTitle("Lab 2 - Radio buttons");
  mainWindow.show();
  return app.exec();
}