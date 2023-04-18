#include <cmath>
#include <iostream>
#include <QtWidgets>

const int DEFAULT_FPS = 60;
const int DEFAULT_ELLIPSE_SIZE = 80;
const int DEFAULT_ANIMATION_DURATION = 3000;

double easeOutElastic(double x)
{
  const double c4 = (2 * M_PI) / 3;
  return x == 0 ? 0 : (x == 1 ? 1 : (pow(2, -10 * x) * sin((x * 10 - 0.75) * c4) + 1));
}

class MainWindow : public QWidget
{
public:
  MainWindow(QWidget *parent = nullptr) : QWidget(parent)
  {
    QFont labelFont("Arial", 16);
    QFont inputLabelFont("Arial", 9);

    QVBoxLayout *titleLayout = new QVBoxLayout();
    titleLayout->setAlignment(Qt::AlignTop);

    layoutLabel = new QLabel("Circle Animation");
    layoutLabel->setFont(labelFont);
    layoutLabel->setAlignment(Qt::AlignCenter);

    titleLayout->addWidget(layoutLabel);

    QVBoxLayout *controlLayout = new QVBoxLayout();
    controlLayout->setAlignment(Qt::AlignBottom);

    QLabel *controlFpsLabel = new QLabel("Animation FPS:");
    controlFpsLabel->setFont(inputLabelFont);
    controlFpsLabel->setAlignment(Qt::AlignLeft);

    layoutFpsInput = new QLineEdit();
    layoutFpsInput->setText(QString::number(DEFAULT_FPS));
    layoutFpsInput->setValidator(new QIntValidator());

    QLabel *controlDurationLabel = new QLabel("Animation duration (ms):");
    controlDurationLabel->setFont(inputLabelFont);
    controlDurationLabel->setAlignment(Qt::AlignLeft);

    layoutDurationInput = new QLineEdit();
    layoutDurationInput->setText(QString::number(DEFAULT_ANIMATION_DURATION));
    layoutDurationInput->setValidator(new QIntValidator());

    QLabel *controlSizeLabel = new QLabel("Elipse size (px):");
    controlSizeLabel->setFont(inputLabelFont);
    controlSizeLabel->setAlignment(Qt::AlignLeft);

    layoutSizeInput = new QLineEdit();
    layoutSizeInput->setText(QString::number(DEFAULT_ELLIPSE_SIZE));
    layoutSizeInput->setValidator(new QIntValidator());

    layoutStartButton = new QPushButton();
    layoutStartButton->setText("Start");

    controlLayout->addWidget(controlFpsLabel);
    controlLayout->addWidget(layoutFpsInput);
    controlLayout->addWidget(controlDurationLabel);
    controlLayout->addWidget(layoutDurationInput);
    controlLayout->addWidget(controlSizeLabel);
    controlLayout->addWidget(layoutSizeInput);
    controlLayout->addWidget(layoutStartButton);

    QVBoxLayout *layout = new QVBoxLayout(this);

    layout->addLayout(titleLayout);
    layout->addLayout(controlLayout);

    timer = new QTimer;

    connect(timer, SIGNAL(timeout()), this, SLOT(update()));
    connect(layoutStartButton, &QPushButton::clicked, this, [this]()
            { this->start(); });
  }

protected:
  void start()
  {
    this->_fps = QString(layoutFpsInput->text()).toInt();
    this->_duration = QString(layoutDurationInput->text()).toInt();
    this->_ellipse_size = QString(layoutSizeInput->text()).toInt();

    if (this->_fps <= 0 || this->_duration <= 0 || this->_ellipse_size <= 0)
      return;

    this->_cache_time = 0;
    this->_cache_fpms = round(1000 / this->_fps);

    layoutFpsInput->setEnabled(false);
    layoutDurationInput->setEnabled(false);
    layoutSizeInput->setEnabled(false);
    layoutStartButton->setEnabled(false);

    timer->start(this->_cache_fpms);
  }

  void stop()
  {
    timer->stop();
    layoutFpsInput->setEnabled(true);
    layoutDurationInput->setEnabled(true);
    layoutSizeInput->setEnabled(true);
    layoutStartButton->setEnabled(true);
  }

  void paintEvent(QPaintEvent *event) override
  {
    this->_cache_time += this->_cache_fpms;

    QPainter painter(this);
    painter.setPen(Qt::NoPen);
    painter.setBrush(Qt::red);
    painter.setRenderHint(QPainter::Antialiasing);

    // Get the working area in pixels.
    double currect_animation_diff = (double)this->animation_to -
                                    (double)this->animation_from -
                                    (double)this->_ellipse_size;

    // Get the current animation stage from 0 to 1.
    double currect_animation_timeline = (double)this->_cache_time /
                                        (double)this->_duration;

    // Center the position of the elipse horizontally.
    double currect_ellipse_x_position = (width() - this->_ellipse_size) / 2;

    // Get the position of the ellipse vertically, where we calculate the
    // percentage of it being in the working area.
    double currect_ellipse_y_position = animation_from +
                                        currect_animation_diff * easeOutElastic(currect_animation_timeline);

    painter.drawEllipse(
        currect_ellipse_x_position,
        currect_ellipse_y_position,
        this->_ellipse_size,
        this->_ellipse_size);

    if (currect_animation_timeline >= 1)
    {
      this->stop();
    }
  }

private:
  QTimer *timer;
  QLabel *layoutLabel;
  QLineEdit *layoutFpsInput;
  QLineEdit *layoutDurationInput;
  QLineEdit *layoutSizeInput;
  QPushButton *layoutStartButton;

  int animation_to = 340;  // px
  int animation_from = 50; // px

  int _fps;          // int
  int _duration;     // ms
  int _ellipse_size; // px
  int _cache_time;   // ms
  int _cache_fpms;   // ms
};

int main(int argc, char *argv[])
{
  QApplication app(argc, argv);
  MainWindow mainWindow;
  mainWindow.setFixedSize(400, 650);
  mainWindow.setWindowTitle("Lab 3 - Qt Drawing");
  mainWindow.show();
  return app.exec();
}