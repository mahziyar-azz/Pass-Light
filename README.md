# Pass Light

Pass Light is a **open source**, lightweight password generator designed to create strong and secure passwords. This program is simple, efficient, and optimized for Windows users.

## Features

- **Password Generation**:
  - Generates random passwords with combinations of:
    - Special characters: ()"\/+\'-=&^%$#@!}{|":?><.
    - All numbers
    - Uppercase and lowercase letters
  - Customizable password length between **12** and **100** characters.
- **AES-256 Encryption**:
  - All generated passwords are encrypted using AES-256 and stored securely at:
    `C:/Passwords`
  - You can change the Secret Key in `SecretKey.cs`!
    - **Considerations**:
      - Changing the Secret Key will make it impossible to decrypt previously saved passwords.
      - Previously saved passwords will only produce correct results if the original key is restored.
      - Ensure you back up the current key before making any changes.
      - Use a strong and secure key to maintain encryption strength.
- **Saved Password Management**:
  - Easily view saved passwords in the "Saved Password" section.
- **User-Friendly Keyboard Navigation**:
  - Fill in the title field.
  - Optionally, set the desired password length (default: 25 characters).
  - Press **Enter** or click the **Generate** button to create a password and copy it to the clipboard automatically.
  - To exit the program, press **ESC** on your key board.

## How to Use

1. Open the program (no installation required).
2. Enter a title in the title field.
3. Set the password length if needed (default is 25 characters).
4. Press **Enter** or click the **Generate** button to generate a password.
5. The password is automatically copied to your clipboard and saved in the encrypted storage.
6. To exit the program, press **ESC**.

## System Requirements
- **Platform**: Windows
- **Installation**: Not required. Simply download and run the program.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Contact
For any questions, suggestions, or feedback, feel free to reach out:

- **Email**: mahziyar.azimzadeh@gmail.com
- **Telegram**: [mahziyar_az](https://t.me/mahziyar_az)

