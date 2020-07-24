from gpiozero import Device
class PinReader:
    def Read(self, pinPosition):
        outputDevice = Device(pinPosition, False)
        return outputDevice.value
    def Write(self, pinPosition):
        outputDevice = Device(pinPosition, False)
        return outputDevice.value
