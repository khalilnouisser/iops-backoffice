<div class="section back-white" id="contact">
    <div class="twelve columns">
        <div class="title-text-main">
            <br><br><br>
            <h1>Contact Us</h1>
        </div>
    </div>
    <div class="section">
        <div class="container">
            <div class="twelve columns remove-top">
                <div class="contact-det-wrap" data-scroll-reveal="enter bottom move 100px over 1s after 0.3s">
                    <div class="contact-det">
                        <p>1. <span>email us</span></p>
                        <h6><a href="mailto:iops.contact@gmail.com">iops.contact@gmail.com</a></h6>
                    </div>
                    <div class="contact-det">
                        <p>2. <span>social media</span></p>
                        <h6><a href="https://www.facebook.com/IOPSnews">facebook page</a></h6>
                    </div>
                    <div class="contact-det">
                        <p>3. <span>address</span></p>
                        <h6>kralja milutina 325</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="section padding-bottom">
        <div class="container">
            <form name="ajax-form" id="ajax-form" action="http://ivang-design.com/talos/12medical/mail-it.php"
                  method="post">
                <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                    <label for="name">
                        <span class="error" id="err-name">please enter name</span>
                    </label>
                    <input name="name" id="name" type="text" placeholder="Your Name: *"/>
                </div>
                <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                    <label for="email">
                        <span class="error" id="err-email">please enter e-mail</span>
                        <span class="error" id="err-emailvld">e-mail is not a valid format</span>
                    </label>
                    <input name="email" id="email" type="text" placeholder="E-Mail: *"/>
                </div>
                <div class="twelve columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                    <label for="message"></label>
                    <textarea name="message" id="message" placeholder="Tell Us Everything"></textarea>
                </div>
                <div class="twelve columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                    <div id="button-con">
                        <button class="send_message button-effect button--moema button--text-thick button--text-upper button--size-s"
                                id="send" data-lang="en">submit
                        </button>
                    </div>
                </div>
                <div class="clear"></div>
                <div class="error text-align-center" id="err-form">There was a problem validating the form please
                    check!
                </div>
                <div class="error text-align-center" id="err-timedout">The connection to the server timed out!</div>
                <div class="error" id="err-state"></div>
            </form>

            <div class="clear"></div>
            <div id="ajaxsuccess">Successfully sent!!</div>
            <div class="clear"></div>
        </div>
    </div>
</div>
