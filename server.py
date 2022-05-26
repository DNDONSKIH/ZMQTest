import time
import zmq
import json

if __name__ == '__main__':
    context = zmq.Context()
    socket = context.socket(zmq.REP)
    socket.bind("tcp://*:5555")

    while True:
        message = socket.recv()

        msg_string = message.decode('utf8')
        json_msg = json.loads(msg_string)

        print(f"Received request: {json_msg}")
        time.sleep(1)

        json_msg["result"] = 10.0
        response = json.dumps(json_msg, indent=4)
        encoded_msg = response.encode()

        socket.send(encoded_msg)
