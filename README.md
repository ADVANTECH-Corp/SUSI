# SUSI
## 1	Introduction
SUSI – A Bridge to Simplify & Enhance H/W & Application Implementation Efficiency
When developers want to write an application that involves hardware access, they have to study the specifications to write the drivers. This is a time-consuming job and requires lots of expertise. 
Advantech has done all the hard work for our customers with the release of a suite of Software APIs (Application Programming Interfaces), called Secured & Unified Smart Interface (SUSI). 
SUSI provides not only the underlying drivers required but also a rich set of user-friendly, intelligent and integrated interfaces, which speeds development, enhances security and offers add-on value for Advantech platforms. SUSI plays the role of catalyst between developer and solution, and makes Advantech embedded platforms easier and simpler to adopt and operate with customer applications.

### 1.1	Functions
#### 1.1.1	GPIO
 
General Purpose Input/Output is a flexible parallel interface that allows a variety of custom connections. It supports various Digital I/O devices – input devices like buttons, switches; output devices such as cash drawers, LED lights…etc. And, allows users to monitor the level of signal input or set the output status to switch on/off the device. Our APIs also provided Programmable GPIO and allows developers to dynamically set the GPIO input or output status.

#### 1.1.2	SMBus
 
SMBus is the System Management Bus defined by Intel® Corporation in 1995. It is used in personal computers and servers for low-speed system management communications. Today, SMBus is used in all types of embedded systems. The SMBus APIs allows a developer to interface a platform to a downstream embedded system environment and transfer serial messages using the SMBus protocols, allowing multiple simultaneous device control.

#### 1.1.3	I2C
 
I2C is a bi-directional two wire bus that was developed by Philips for use in their televisions in the 1980s. Today, I2C is used in all types of embedded systems. The I2C API allows a developer to interface a platform to a downstream embedded system environment and transfer serial messages using the I2C protocols, allowing multiple simultaneous device control.

#### 1.1.4	Watchdog
 
A watchdog timer (WDT) is a device or electronic card that performs a specific operation after a certain period of time if something goes wrong with an electronic system and the system does not recover on its own.
A watchdog timer can be programmed to perform a warm boot (restarting the system) after a certain number of seconds during which a program or computer fails to respond following the most recent mouse click or keyboard action.

#### 1.1.5	Hardware Monitor
   
The Hardware Monitor (HWM) APIs is a system health supervision API that inspects certain condition indexes, such as smart fan, fan speed, temperature, current, case open and voltage.

#### 1.1.6	Backlight Control
   
The Backlight Control APIs allows a developer to interface platform to easily control brightness through PWM and backlight on/off.

#### 1.1.7	Storage
 
Storage is a non-volatile storage, the storage APIs allows a developer to access storage information, read/write data to storage and lock/unlock data area (same like write protection) by a key.

#### 1.1.8	Thermal Protection
   
Thermal Protection can select a thermal source to monitor. When source temperature reach the limit, SUSI can act protect function to protect system.

### 1.2	Benefits
#### Faster Time to Market
SUSI's unified API helps developers write applications to control the hardware without knowing the hardware specs of the chipsets and driver architecture.

#### Reduced Project Effort
When customers have their own devices connected to the onboard bus, they can either: study the data sheet and write the driver & API from scratch, or they can use SUSI to start the integration with a 50% head start. Developers can reference the sample program on the CD to see and learn more about the software development environment.

#### Enhances Hardware Platform Reliability
SUSI provides a trusted custom ready solution which combines chipset and library function support, controlling application development through SUSI enhances reliability and brings peace of mind. 

#### Flexible Upgrade Possibilities
SUSI supports an easy upgrade solution for customers. Customers just need to install the new version SUSI that supports the new functions.

#### Backward compatibility
Support SUSI 3.0, iManager 2.0 and EAPI 1.0 interface. Customers don’t need to change any APIs in their applications.

