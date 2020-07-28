from gpiozero import Device
class PinReader:
    def Read(self, pinPosition):
        outputDevice = Device(pinPosition)
        return outputDevice.value

    def Write(self, pinPosition):
        outputDevice = Device(pinPosition)
        return outputDevice.value
