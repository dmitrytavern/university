#include <QtWidgets>

class MainWindow : public QWidget
{
public:
  MainWindow(QWidget *parent = nullptr) : QWidget(parent)
  {
    QHBoxLayout *layout = new QHBoxLayout(this);
    QFont labelFont("Arial", 11);

    // Image radio buttons
    QLabel *imageLabel = new QLabel("Select image:");
    imageLabel->setFont(labelFont);
    imageLabel->setContentsMargins(0, 30, 0, 0);

    imageButtonGroup = new QButtonGroup(this);
    imageButtonGroup->setExclusive(true);

    imageButton1 = new QRadioButton("Image 1");
    imageButton2 = new QRadioButton("Image 2");
    imageButton3 = new QRadioButton("Image 3");
    imageButton1->setChecked(true);

    imageButtonGroup->addButton(imageButton1, 0);
    imageButtonGroup->addButton(imageButton2, 1);
    imageButtonGroup->addButton(imageButton3, 2);

    QVBoxLayout *imageButtonLayout = new QVBoxLayout();
    imageButtonLayout->addWidget(imageLabel);
    imageButtonLayout->addWidget(imageButton1);
    imageButtonLayout->addWidget(imageButton2);
    imageButtonLayout->addWidget(imageButton3);

    // Color radio buttons
    QLabel *colorLabel = new QLabel("Select background:");
    colorLabel->setFont(labelFont);
    colorLabel->setContentsMargins(0, 30, 0, 0);

    colorButtonGroup = new QButtonGroup(this);
    colorButtonGroup->setExclusive(true);

    colorButton1 = new QRadioButton("Add background");
    colorButton2 = new QRadioButton("Remove background");
    colorButton2->setChecked(true);

    colorButtonGroup->addButton(colorButton1, 0);
    colorButtonGroup->addButton(colorButton2, 1);

    QVBoxLayout *colorButtonLayout = new QVBoxLayout();
    colorButtonLayout->addWidget(colorLabel);
    colorButtonLayout->addWidget(colorButton1);
    colorButtonLayout->addWidget(colorButton2);

    // Add image
    QVBoxLayout *imageLayout = new QVBoxLayout();
    image = new QLabel(this);
    image->setPixmap(QPixmap(":/resources/1.png"));
    image->setFixedSize(400, 400);
    imageLayout->addWidget(image);

    // Setting buttons to one layout
    QVBoxLayout *buttonsLayout = new QVBoxLayout();
    buttonsLayout->addLayout(imageButtonLayout);
    buttonsLayout->addLayout(colorButtonLayout);
    buttonsLayout->setAlignment(Qt::AlignTop);

    // Setting main layout
    layout->addLayout(buttonsLayout);
    layout->addLayout(imageLayout);

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
  mainWindow.setFixedSize(740, 500);
  mainWindow.setWindowTitle("Lab 2 - Radio buttons");
  mainWindow.show();
  return app.exec();
}